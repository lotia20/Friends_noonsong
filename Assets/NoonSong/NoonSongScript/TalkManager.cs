using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; // 대사를 저장하는 Dictionary
    Dictionary<int, Sprite> portraitData; // 초상화를 저장하는 Dictionary

    public Sprite[] portraitArr; // Inspector에서 설정할 수 있는 초상화 배열

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        // 대사 데이터 추가
        talkData.Add(0, new string[] {
            "숙명여대에 갓 입학한 새송이는 학교 탐방을 오게 되었다!:0", // 나레이션
            "근데 어쩌지? 학교가 너무 복잡해!:0", // 나레이션
            "[학교가 처음이라 막막하네...]:0", // 유저 버튼 클릭

            // 사용자가 버튼 클릭하면
            // 눈덩이 활성화

            "안녕, 친구야! 혹시 무슨 고민 있어?:1",
            "[(사정을 설명한다.)]:0",
            "아하, 아직 학교가 처음이라 모르는게 많다고? 음...어디보자~:1",
            "그렇지! 숙명여대라면 역시 눈송이! 그 애가 널 도와줄 수 있을 거야!:1",
            "같이 학교를 돌아다니면서 눈송이가 어디에 있는지 찾아보자!:1"

        });
        talkData.Add(1, new string[] {
            "저기 하늘에 떠 다니는 건 뭐지?:0",
            "어디, 어디?:1",
            "우리는! / 학교를 지키는 어벤져스, 눈꽃송이들이야!:1000",
            "마침 잘 만났다! 얘들아, 이 새송이가 눈송이와 친구가 되고 싶대!:1",
            "그런 거라면.. 눈송이는 눈의 결정을 좋아하니까, 눈의 결정을 준다면 분명 친구가 될 수 있을거야:1000",
            "마침 우리한테 꿍쳐 놓은 눈의 결정이 있으니까, 너한테 줄게!:1000",
            "어려운 친구를 돕는 것도 우리 일이니까, 우리가 새송이를 도와주는 건 어떨까? (뭉치면 산다!) :1000",
            "그래, 눈의 결정이라면 우리가 전문이니까, 함께 다니면서 눈의 결정 찾는 걸 도와줄게! (맡겨 줘!):1000",
            "[고마워, 눈꽃송이들!]:0"

        });
        talkData.Add(2, new string[] {
            "앗! 찾았다!:2000",
            "[앗?!]:0",
            "네가 눈송이를 찾아 다닌다는 새송이 맞지! 소식을 듣고 한달음에 달려왔어!:2000",
            "로로잖아! 과연 학교의 소식통이라 그런지, 소식이 빠르네!:1",
            "히히, 1캠퍼스 정문에서 눈송이를 본 것 같다는 걸 알려주려고!:2000",
            "새송이가 누군지 궁금하기도 했고!:2001",
            "아직 학교 지리는 잘 모르지? 내가 같이 가 줄게!:2000"

        });
        talkData.Add(3, new string[] {
            "저기,, 안녕하세요! 처음 보는 분이네요..! :3000",
            "눈결이 안녕! 혹시 근처에서 눈송이 못봤어?:1",
            "눈송이 말인가요? 음... 못 봤어요. 무슨 일이신데요?:3001",
            "[(눈결이에거 사정을 설명한다)]:0",
            "앗, 그렇다면 이게 도움이 될 거예요!:3001",
            "저는 지도를 잘 보거든요. 그 외에 이것저것 많은 것을 알고 있으니까, 제 지식이 도움이 될 수 있을 것 같아요.:3000",
            "[(그럼 혹시 도와줄 수 있냐고 묻는다.)]:0",
            "물론이에요..! 저도 동행할게요.:3002",
            "으~음.. 눈송이 대신 눈결이가 있었네. 괜찮아! 마침 한 곳 더 짐작이 가는 곳이 있어!:2000",
            "2캠퍼스 정문으로 가보자!:2000"

        });
        talkData.Add(4, new string[] {
            "안녕, 친구들? 처음 보는 친구도 있구나! 새송이인가 보네?:4000",
            "이 친구는 꽃송이야! 눈송이의 베프인 꽃송이라면 눈송이가 어디 있는지 알 지도 몰라!:2000",
            "눈송이? 너희 눈송이를 찾고 있니?:4001",
            "맞아요. 새송이가 눈송이와 친구가 되고 싶대요.:3000",
            "그렇다면 정확히 찾아 왔어. 마침 방금 전까지 눈소이랑 함께 있떤 참이었거든.:4000",
            "아마 눈송이는 프라임관에 있을 거야! 어딘지 아니? 같이 가 줄게.:4001"
        });

        talkData.Add(5, new string[] {
            "찾았다.눈송이!:4000",
            "안녕, 친구들! 어라, 처음 보는 친구도 있네?:5000",
            "이 애가 너와 친구가 되고 싶다고 해서 데려왔어!:1",
            "눈송이를 위한 선물도 가져왔어! (두근두근...!):1000",
            "와아, 눈의 결정이네! 정말 기뻐!:5000",
            "이렇게 찾아와 줘서 고마워, 그럼 우리 오늘부터 친구 하자!:5002",
            "[(눈송이와 친구가 되자.)]:0"
        });

        talkData.Add(6, new string[] {
            "앗~! 다들 나만 빼고 모여 있었구나!:6000",
            "어라? 못 보던 얼굴도 있네?:6000",
            "[(인사한다.)]:0",
            "안녕 튜리! 이 애는 새로운 눈송이인데, 나랑 친구가 되고 싶다고 찾아와 줬어!:5003",
            "오... 이해했어!:6000",
            "거기 눈송, 좀 더 다양한 눈송이를 만나보고 싶지 않아?:6000",
            "[(고개를 끄덕인다.)]:0",

        });

        // 초상화 데이터 추가
        portraitData.Add(0 + 0, portraitArr[0]); //유저
        portraitData.Add(0 + 1, portraitArr[1]); //눈덩이
        portraitData.Add(1000 + 0, portraitArr[2]); //눈꽃송이
        portraitData.Add(2000 + 0, portraitArr[3]); //로로
        portraitData.Add(2000 + 1, portraitArr[4]); //로로
        portraitData.Add(3000 + 0, portraitArr[5]); //눈결이
        portraitData.Add(3000 + 1, portraitArr[6]); //눈결이
        portraitData.Add(3000 + 2, portraitArr[7]); //눈결이
        portraitData.Add(4000 + 0, portraitArr[8]); //꽃송이
        portraitData.Add(4000 + 1, portraitArr[9]); //꽃송이
        portraitData.Add(5000 + 0, portraitArr[10]); //눈송이
        portraitData.Add(5000 + 1, portraitArr[11]); //눈송이
        portraitData.Add(5000 + 2, portraitArr[12]); //눈송이
        portraitData.Add(5000 + 3, portraitArr[13]); //눈송이
        portraitData.Add(6000 + 0, portraitArr[14]); //튜리

    }

    // 특정 패널 ID의 대사 가져오기
    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); //튜토리얼
            else
                return GetTalk(id - id % 10, talkIndex); //퀘스트
        }
        if (talkIndex >= talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    // 특정 패널 ID의 초상화 가져오기
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        int key = portraitIndex;
        if (!portraitData.ContainsKey(key))
        {
            Debug.LogWarning($"Portrait data for key {key} not found. Returning default sprite.");
            return null; // 또는 기본값으로 사용할 스프라이트를 반환
        }
        return portraitData[key];
    }
}
