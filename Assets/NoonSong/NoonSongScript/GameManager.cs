using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        StartCoroutine(ShowInitialDialogues());
    }

    // 초기 대화창 3개를 순차적으로 표시
    public IEnumerator ShowInitialDialogues()
    {
        for (int i = 0; i < 3; i++) // 초기 3개 대화창 표시
        {
            ShowNextDialogue();
            yield return new WaitUntil(() => !isShowingDialogue); // 대화창이 숨겨질 때까지 대기
        }
    }

    // 특정 위치에 도착했을 때 대화창을 표시
    public void ShowDialogueAtLocation(int locationIndex)
    {
        if (locationIndex == currentPanelIndex && currentPanelIndex >= 3)
        {
            ShowNextDialogue();
        }
    }

    // 다음 대화창을 표시하는 메소드
    public void ShowNextDialogue()
    {
        if (currentPanelIndex < dialogues.Length && !isShowingDialogue)
        {
            isShowingDialogue = true; // 대화창 표시 중으로 설정
            TalkPanel talkPanel = dialogues[currentPanelIndex].GetComponent<TalkPanel>();
            talkPanel.ShowDialogue();
            Debug.Log("After Show Dialogue currentPanelIndex: " + currentPanelIndex);
            currentPanelIndex++;
        }
    }

    // 대화가 끝난 후 호출되는 메소드
    public void OnDialogueHidden(int panelId)
    {
        if (panelId < 2)
        {
            isShowingDialogue = false; // 대화창이 숨겨졌음을 표시
            ShowNextDialogue();
        }
        else
        {
            isShowingDialogue = false; // 대화창이 숨겨졌음을 표시
        }
    }
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GameManager : MonoBehaviour
// {
//     public GameObject[] dialogues; // 대화창을 배열로 관리
//     public int panelIdGM = 0; // 현재 대화창 인덱스

//     void Start()
//     {
//         // 모든 대화창 비활성화
//         foreach (GameObject dialogue in dialogues)
//         {
//             dialogue.SetActive(false);
//         }
//         StartCoroutine(ShowInitialDialogues());

//     }

//     // 초기 대화창 3개를 순차적으로 표시
//     public IEnumerator ShowInitialDialogues()
//     {
//         for (int i = 0; i < 2; i++) // 초기 3개 대화창 표시
//         {
//             ShowNextDialogue();
//             Debug.Log("ShowInitialDialogues");
//             yield return new WaitUntil(() => dialogues[panelIdGM - 1].activeSelf == false);
//         }
//     }

//     // 특정 위치에 도착했을 때 대화창을 표시
//     public void ShowDialogue22(int locationIndex)
//     {
//         if (locationIndex == panelIdGM)
//         {
//             ShowNextDialogue(); // 네 번째 대화창부터는 특정 위치에 도착해야만 표시
//         }
//     }

//     // 다음 대화창을 표시하는 메소드
//     public void ShowNextDialogue()
//     {
//         if (panelIdGM < dialogues.Length)
//         {
//             TalkPanel talkPanel = dialogues[panelIdGM].GetComponent<TalkPanel>();
//             talkPanel.ShowDialogue();
//             Debug.Log("panelIdforGM: " + panelIdGM);
//            //panelId++;

//         }
//         else
//         {
//             return;
//         }

//     }

//     // 대화가 끝난 후 호출되는 메소드
//     public void OnDialogueHidden()
//     {
//         // 초기 3개 대화창은 바로 다음 대화창을 표시
//         if (panelIdGM < 2)
//         {
//             ShowNextDialogue();
//         }
//     }
// }


