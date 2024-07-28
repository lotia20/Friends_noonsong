using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkPanel : MonoBehaviour
{
    public Text dialogueText; // 대화 텍스트를 표시하는 UI 요소
    public Image portraitImage; // 캐릭터 초상화를 표시하는 UI 이미지
    public int panelId; // 패널의 고유 ID, TalkManager에서 사용됨
    public Animator animator; // 패널의 애니메이터 컴포넌트

    private int talkIndex = 0; // 현재 대화 인덱스
    private TalkManager talkManager; // 대화 정보를 관리하는 TalkManager 객체
    private bool dialogueEnded = false; // 대화 종료 여부를 나타내는 플래그

    void Awake()
    {
        talkManager = FindObjectOfType<TalkManager>(); // Scene에서 TalkManager를 찾아 할당
    }

    // 다음 대화를 표시하는 메소드
    public void DisplayNextDialogue()
    {
        string dialogue = talkManager.GetTalk(panelId, talkIndex); // TalkManager에서 해당 패널의 대화 내용 가져오기
        if (dialogue == null)
        {
            dialogueEnded = true; // 대화가 끝났음을 표시
            HideDialogue(); // 대화 패널 숨기기
            return;
        }

        string[] parts = dialogue.Split(':'); // 대화 내용과 캐릭터 초상화 인덱스 분리
        if (parts.Length == 2)
        {
            dialogueText.text = parts[0]; // 대화 텍스트 설정
            int portraitIndex = int.Parse(parts[1]); // 캐릭터 초상화 인덱스 파싱
            Sprite portrait = talkManager.GetPortrait(panelId, portraitIndex); // 해당 캐릭터 초상화 가져오기
            if (portrait != null)
            {
                portraitImage.sprite = portrait; // UI 이미지에 초상화 설정
            }
        }
        talkIndex++; // 다음 대화 인덱스로 이동
    }

    // "다음" 버튼 클릭 시 호출되는 메소드
    public void OnClickNext()
    {
        DisplayNextDialogue(); // 다음 대화 표시
    }

    // 패널을 활성화하고 첫 대사를 표시하는 메소드
    public void ShowDialogue()
    {
        gameObject.SetActive(true); // 패널 활성화
        animator.SetBool("isShow", true); // 애니메이션 트리거 설정
        talkIndex = 0; // 대화 인덱스 초기화
        dialogueEnded = false; // 대화 종료 플래그 초기화
        DisplayNextDialogue(); // 첫 번째 대화 표시
    }

    // 패널을 비활성화하는 메소드
    public void HideDialogue()
    {
        animator.SetBool("isShow", false); // 애니메이션 트리거 설정
        StartCoroutine(HideDialogueCoroutine()); // 숨기기 코루틴 시작
    }

    // 애니메이션 종료 후 패널 비활성화
    IEnumerator HideDialogueCoroutine()
    {
        yield return new WaitForSeconds(1.0f); // 1초 대기
        OnHideAnimationEnd(); // 숨기기 완료 후 처리
    }

    // 숨기기 애니메이션 완료 후 호출되는 메소드
    public void OnHideAnimationEnd()
    {
        gameObject.SetActive(false); // 패널 비활성화
        FindObjectOfType<GameManager>().OnDialogueHidden(panelId); // GameManager에 패널 ID 전달하여 대화 종료 처리
    }
}