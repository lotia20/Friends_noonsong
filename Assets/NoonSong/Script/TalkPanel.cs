using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkPanel : MonoBehaviour
{
    public Text dialogueText;
    public Image portraitImage;
    public int panelId; // 패널 ID, TalkManager에서 사용됨
    public Animator animator; // 애니메이터 컴포넌트

    private int talkIndex = 0;
    private TalkManager talkManager;
    private bool dialogueEnded = false;

    void Start()
    {
        talkManager = FindObjectOfType<TalkManager>();
    }

    // 다음 대화를 표시하는 메소드
    public void DisplayNextDialogue()
    {
        string dialogue = talkManager.GetTalk(panelId, talkIndex);
        if (dialogue == null)
        {
            dialogueEnded = true;
            HideDialogue();
            return;
        }

        string[] parts = dialogue.Split(':');
        if (parts.Length == 2)
        {
            dialogueText.text = parts[0];
            int portraitIndex = int.Parse(parts[1]);
            Sprite portrait = talkManager.GetPortrait(panelId, portraitIndex);
            if (portrait != null)
            {
                portraitImage.sprite = portrait;
            }
        }
        talkIndex++;
    }

    // "다음" 버튼 클릭 시 호출되는 메소드
    public void OnClickNext()
    {
        DisplayNextDialogue();
    }

    // 패널을 활성화하고 첫 대사를 표시하는 메소드
    public void ShowDialogue()
    {
        gameObject.SetActive(true);
        animator.SetBool("isShow", true);
        talkIndex = 0; // 대화 인덱스를 0으로 초기화
        dialogueEnded = false;
        DisplayNextDialogue();
    }

    // 패널을 비활성화하는 메소드
    public void HideDialogue()
    {
        animator.SetBool("isShow", false);
        StartCoroutine(HideDialogueCoroutine());
    }

    // 애니메이션 종료 후 패널 비활성화
    IEnumerator HideDialogueCoroutine()
    {
        yield return new WaitForSeconds(1.0f); // 1초 대기
        OnHideAnimationEnd();
    }

    public void OnHideAnimationEnd()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().OnDialogueHidden(panelId);
    }
}
