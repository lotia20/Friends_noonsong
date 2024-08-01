using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 튜토리얼 Part1 스크립트 진행 : part별로 스크립트를 나누는게 관리하기에 좋을 듯 하여 나누어보았습니다. 함수는 다른 스크립트에서 참조합니다.//
// 1. 튜토리얼 씬 시작
// 2. 나레이션이 대사가 먼저 UI창에 나옴
// 3. 유저 대사로 막막하다는 대사 뜸 (유저대사 = 버튼)
// 4. 버튼 클릭시 눈덩이 움직이는거 시작
// 5. 눈덩이 모델링이 화면 밖에서 날아와서 중앙에 도착
// 6. 눈덩이가 중앙에 도착하면 대사가 시작됨
// 7. 중간에 유저 대사 부분은 중앙에 대사 버튼 뜨고 유저가 버튼 클릭하면 다시 눈덩이 대사 진행
// 7. 눈덩이 대사랑 애니메이션 시작

public class TutorialPart1 : MonoBehaviour
{
    private TalkManager talkManager;

    public GameObject dialoguePanel; // 대화 패널
    public Text dialogueText; // 대화 내용 텍스트
    public Button userButton; // 유저 버튼
    public Animator snowballAnimator; // 눈덩이 애니메이터
    public GameObject snowball; // 눈덩이 모델링

    private Queue<string> sentences; // 대화 문장을 저장할 큐
    private bool isDialogueStarted = false; // 대화 시작 여부

    void Start()
    {
        talkManager = FindObjectOfType<TalkManager>(); // TalkManager를 찾아서 참조
        sentences = new Queue<string>(); // 큐 초기화

        // 패널과 눈덩이 모델링 초기 상태 설정
        dialoguePanel.SetActive(false);
        snowball.SetActive(false);

        // 유저 버튼 클릭 이벤트 리스너 설정
        userButton.onClick.AddListener(OnUserButtonClick);

        // 튜토리얼 시작
        StartCoroutine(StartTutorial());
    }

    private IEnumerator StartTutorial()
    {
        // 1. 튜토리얼 씬 시작
        yield return new WaitForSeconds(1f); // 1초 대기

        // 2. 나레이션이 대사가 먼저 UI창에 나옴
        StartDialogue(new string[] { talkManager.GetTalk(0, 0) });

        // 대화가 끝날 때까지 대기
        yield return new WaitUntil(() => !isDialogueStarted);

        // 3. 유저 대사로 막막하다는 대사 뜸 (유저 대사 = 버튼)
        StartDialogue(new string[] { talkManager.GetTalk(0, 2) });

        // 대화가 끝날 때까지 대기
        yield return new WaitUntil(() => !isDialogueStarted);

        // 4. 버튼 클릭 시 눈덩이 움직이는거 시작
        userButton.gameObject.SetActive(true); // 유저 버튼 활성화
    }

    private void OnUserButtonClick()
    {
        userButton.gameObject.SetActive(false); // 유저 버튼 비활성화
        StartCoroutine(MoveSnowball());
    }

    private IEnumerator MoveSnowball()
    {
        // 5. 눈덩이 모델링이 화면 밖에서 날아와서 중앙에 도착
        snowball.SetActive(true); // 눈덩이 모델링 활성화
        snowballAnimator.Play("SnowballEnter"); // 눈덩이 입장 애니메이션 재생

        yield return new WaitForSeconds(2f); // 애니메이션 재생 시간 대기

        // 6. 눈덩이가 중앙에 도착하면 대사가 시작됨
        StartDialogue(new string[] { talkManager.GetTalk(0, 3), talkManager.GetTalk(0, 4) });

        // 7. 중간에 유저 대사 부분은 중앙에 대사 버튼 뜨고 유저가 버튼 클릭하면 다시 눈덩이 대사 진행
        // 추가 대사 및 버튼 클릭 로직을 여기에 구현

        // 8. 눈덩이 대사랑 애니메이션 시작
        yield return new WaitForSeconds(1f); // 예시: 1초 대기 후 애니메이션 시작
        snowballAnimator.Play("SnowballTalk"); // 눈덩이 대화 애니메이션 재생
    }

    public void StartDialogue(string[] dialogue)
    {
        isDialogueStarted = true; // 대화 시작 상태 업데이트
        sentences.Clear(); // 큐 초기화

        // 대화 문장을 큐에 추가
        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        dialoguePanel.SetActive(true); // 대화 패널 활성화
        DisplayNextSentence(); // 첫 번째 문장 표시
    }

    public void DisplayNextSentence()
    {
        // 대화 문장이 없으면 대화 종료
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 큐에서 문장을 꺼내 텍스트에 표시
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        isDialogueStarted = false; // 대화 종료 상태 업데이트
        dialoguePanel.SetActive(false); // 대화 패널 비활성화
    }
}