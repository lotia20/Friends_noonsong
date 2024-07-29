using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// 주요기능 //
// ShowPanel() 및 HidePanel() 메소드를 통해 대화 패널을 표시하거나 숨김
// StartDialogue() 메소드로 대화 문장을 시작하며, DisplayNextSentence() 메소드로 문장을 하나씩 표시
// EndDialogue() 메소드로 대화를 종료하고, 일정 시간 후 패널을 숨김

public class TutorialManager : MonoBehaviour
{
    public GameObject dialoguePanel; // 대화 패널
    public Text dialogueText; // 대화 내용 텍스트
    public Button nextButton; // 다음 버튼
    public Animator talkPanelMove; // 패널 애니메이터

    private Queue<string> sentences; // 대화 문장을 저장할 큐
    private bool isPanelVisible = false; // 패널의 현재 가시성 상태
    private bool isDialogueStarted = false; // 대화 시작 여부

    void Start()
    {
        sentences = new Queue<string>(); // 큐 초기화
        HidePanel();  // 시작할 때 패널 숨기기
        nextButton.onClick.AddListener(DisplayNextSentence); // 버튼 클릭 시 다음 문장 표시
        Debug.Log("Button listener added in Start."); // 디버그 로그
    }

    void Update()
    {
        // 패널이 보이지 않을 때, 클릭 시 패널 표시
        if (!isPanelVisible && Input.GetMouseButtonDown(0))
        {
            ShowPanel();
        }
        // 패널이 보이고 대화가 시작되지 않았을 때, 클릭 시 대화 시작
        else if (isPanelVisible && !isDialogueStarted && Input.GetMouseButtonDown(0))
        {
            StartDialogue(new string[] {
                "숙명여대에 갓 입학한 새송이는 학교 탐방을 오게 되었다!",
                "그런데 어쩌지? \n 학교가 너무 복잡해!",
                "[학교가 처음이라 막막하네..]",
                "안녕 친구야! \n 혹시 무슨 고민 있어?"
            });
        }
    }

    // 패널을 표시하는 메소드
    void ShowPanel()
    {
        dialoguePanel.SetActive(true); // 패널 활성화
        isPanelVisible = true; // 패널 표시 상태 업데이트
        talkPanelMove.SetBool("isShow", true); // 애니메이터 상태 업데이트
        Debug.Log("Panel is showing"); // 디버그 로그
    }

    // 패널을 숨기는 메소드
    void HidePanel()
    {
        isPanelVisible = false; // 패널 비표시 상태 업데이트
        dialoguePanel.SetActive(false); // 패널 비활성화
        talkPanelMove.SetBool("isShow", false); // 애니메이터 상태 업데이트
        Debug.Log("Panel is hiding"); // 디버그 로그
    }

    // 대화를 시작하는 메소드
    public void StartDialogue(string[] dialogue)
    {
        Debug.Log("StartDialogue called"); // 디버그 로그
        isDialogueStarted = true; // 대화 시작 상태 업데이트
        sentences.Clear(); // 큐 초기화

        // 대화 문장을 큐에 추가
        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(); // 첫 번째 문장 표시
    }

    // 다음 문장을 표시하는 메소드
    public void DisplayNextSentence()
    {
        Debug.Log("DisplayNextSentence called"); // 디버그 로그

        // 마지막 문장을 출력하기 전에 리스너를 제거
        if (sentences.Count == 1)
        {
            nextButton.onClick.RemoveListener(DisplayNextSentence);
        }

        // 대화 문장이 없으면 대화 종료
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 큐에서 문장을 꺼내 텍스트에 표시
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log("Next sentence: " + sentence); // 디버그 로그
    }

    // 대화를 종료하는 메소드
    void EndDialogue()
    {
        Debug.Log("EndDialogue called"); // 디버그 로그
        isDialogueStarted = false; // 대화 종료 상태 업데이트
        talkPanelMove.SetBool("isShow", false); // 애니메이터 상태 업데이트
        Invoke("HidePanel", 1f); // 1초 후에 패널을 숨김
    }
}