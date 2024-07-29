using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 주요내용 //
// Start() 메소드에서 모든 대화창을 비활성화하고 초기 대화창을 표시
// ShowInitialDialogues() 코루틴을 사용해 초기 3개의 대화창을 순차적으로 표시
// ShowDialogueAtLocation(int locationIndex) 메소드로 특정 위치에서 대화창을 표시
// ShowNextDialogue() 메소드로 다음 대화창을 표시하며, OnDialogueHidden(int panelId) 메소드로 대화가 끝난 후 다음 대화창을 표시

public class GameManager : MonoBehaviour
{
    public GameObject[] dialogues; // 대화창을 배열로 관리
    private int currentPanelIndex = 0; // 현재 대화창 인덱스
    public bool isShowingDialogue = false; // 대화창 표시 중인지 여부

    void Start()
    {
        // 모든 대화창 비활성화
        foreach (GameObject dialogue in dialogues)
        {
            dialogue.SetActive(false);
        }
        StartCoroutine(ShowInitialDialogues()); // 초기 대화창 3개를 순차적으로 표시
    }

    // 초기 대화창 3개를 순차적으로 표시
    public IEnumerator ShowInitialDialogues()
    {
        for (int i = 0; i < 3; i++) // 초기 3개 대화창 표시
        {
            ShowNextDialogue(); // 다음 대화창 표시
            yield return new WaitUntil(() => !isShowingDialogue); // 대화창이 숨겨질 때까지 대기
        }
    }

    // 특정 위치에 도착했을 때 대화창을 표시
    public void ShowDialogueAtLocation(int locationIndex)
    {
        // 현재 위치가 대화창 인덱스와 같고, 현재 대화창 인덱스가 3 이상일 때
        if (locationIndex == currentPanelIndex && currentPanelIndex >= 3)
        {
            ShowNextDialogue(); // 다음 대화창 표시
        }
    }

    // 다음 대화창을 표시하는 메소드
    public void ShowNextDialogue()
    {
        // 현재 인덱스가 대화창 배열 범위 내에 있고, 대화창이 표시 중이지 않을 때
        if (currentPanelIndex < dialogues.Length && !isShowingDialogue)
        {
            isShowingDialogue = true; // 대화창 표시 중으로 설정
            TalkPanel talkPanel = dialogues[currentPanelIndex].GetComponent<TalkPanel>(); // 현재 대화창 가져오기
            talkPanel.ShowDialogue(); // 대화창 표시
            Debug.Log("After Show Dialogue currentPanelIndex: " + currentPanelIndex); // 디버그 로그
            currentPanelIndex++; // 인덱스 증가
        }
    }

    // 대화가 끝난 후 호출되는 메소드
    public void OnDialogueHidden(int panelId)
    {
        // 패널 ID가 2보다 작은 경우
        if (panelId < 2)
        {
            isShowingDialogue = false; // 대화창이 숨겨졌음을 표시
            ShowNextDialogue(); // 다음 대화창 표시
        }
        else
        {
            isShowingDialogue = false; // 대화창이 숨겨졌음을 표시
        }
    }
}