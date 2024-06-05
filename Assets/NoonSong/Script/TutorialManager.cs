using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Button nextButton;
    public Animator talkPanelMove;

    private Queue<string> sentences;
    private bool isPanelVisible = false;
    private bool isDialogueStarted = false;

    void Start()
    {
        sentences = new Queue<string>();
        HidePanel();  // 시작할 때 패널 숨기기
        nextButton.onClick.AddListener(DisplayNextSentence);
        Debug.Log("Button listener added in Start.");
    }

    void Update()
    {
        if (!isPanelVisible && Input.GetMouseButtonDown(0))
        {
            ShowPanel();
        }
        else if (isPanelVisible && !isDialogueStarted && Input.GetMouseButtonDown(0))
        {
            StartDialogue(new string[] {
                "숙명여대에 갓 입학한 새송이는 학교 탐방을 오게 되었다!",
                "그런데 어쩌지? \n 학교가 너무 복잡해!",
                "학교가 처음이라 막막하네..",
                "안녕 친구야! \n 혹시 무슨 고민 있어?"
            });
        }
    }

    void ShowPanel()
    {
        dialoguePanel.SetActive(true);
        isPanelVisible = true;
        talkPanelMove.SetBool("isShow", true);
        Debug.Log("Panel is showing");
    }

    void HidePanel()
    {
        isPanelVisible = false;
        dialoguePanel.SetActive(false);
        talkPanelMove.SetBool("isShow", false);
        Debug.Log("Panel is hiding");
    }

    public void StartDialogue(string[] dialogue)
    {
        Debug.Log("StartDialogue called");
        isDialogueStarted = true;
        sentences.Clear();

        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("DisplayNextSentence called");

        if (sentences.Count == 1) // 마지막 문장을 출력하기 전에 리스너를 제거
        {
            nextButton.onClick.RemoveListener(DisplayNextSentence);
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log("Next sentence: " + sentence);
    }

    void EndDialogue()
    {
        Debug.Log("EndDialogue called");
        isDialogueStarted = false;
        talkPanelMove.SetBool("isShow",false);
        Invoke("HidePanel", 1f); // 1초 후에 패널을 숨김
    }
}
