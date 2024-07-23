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
            "숙명여대에 갓 입학한 새송이는 학교 탐방을 오게 되었다!:0",
            "근데 어쩌지? 학교가 너무 복잡해!:0",
            "[학교가 처음이라 막막하네...]:0",
            "안녕, 친구야! 혹시 무슨 고민 있어?:1000",
            "[(사정을 설명한다.)]:1000",
            "아하, 아직 학교가 처음이라 모르는게 많다고? 음...어디보자~:2001",
            "그렇지! 숙명여대라면 역시 눈송이! 그 애가 널 도와줄 수 있을 거야!:2002",
            "같이 학교를 돌아다니면서 눈송이가 어디에 있는지 찾아보자!:2003"
        });
        talkData.Add(1, new string[] {
            "저기 하늘에 떠 다니는 건 뭐지?:2000",
            "어디, 어디?:2000",
            "우리는! / 학교를 지키는 어벤져스, 눈꽃송이들이야!:2000",
            "마침 잘 만났다! 얘들아, 이 새송이가 눈송이와 친구가 되고 싶대!:2000",
            "그런 거라면.. 눈송이는 눈의 결정을 좋아하니까, 눈의 결정을 준다면 분명 친구가 될 수 있을거야:2000"
        });
        talkData.Add(2, new string[] {
            "앗! 찾았다!:2000",
            "[앗?!]:1000",
            "네가 눈송이를 찾아 다닌다는 새송이 맞지! 소식을 듣고 한달음에 달려왔어!:2000",
            "로로잖아! 과연 학교의 소식통이라 그런지, 소식이 빠르네!:2000",
            "히히, 1캠퍼스 정문에서 눈송이를 본 것 같다는 걸 알려주려고!:2000"
        });
        talkData.Add(3, new string[] {
            "저기,, 안녕하세요! 처음 보는 분이네요..! :2000",
            "눈결이 안녕! 혹시 근처에서 눈송이 못봤어?:2000"
        });
        talkData.Add(4, new string[] {
            "4번째 대사:0"
        });

        talkData.Add(5, new string[] {
            "다섯번째 대사:1000"
        });

        talkData.Add(6, new string[] {
            "여섯번째 대사:2003"
        });

        // 초상화 데이터 추가
        portraitData.Add(0 + 0, portraitArr[0]); // 나레이션 초상화
        portraitData.Add(0 + 1, portraitArr[1]); // 나레이션 초상화
        portraitData.Add(1000 + 0, portraitArr[2]); // 유저 초상화
        portraitData.Add(2000 + 0, portraitArr[3]); // 눈덩이 초상화
        portraitData.Add(2000 + 1, portraitArr[4]); // 눈덩이 초상화
        portraitData.Add(2000 + 2, portraitArr[5]); // 눈덩이 초상화
        portraitData.Add(2000 + 3, portraitArr[6]); // 눈덩이 초상화
        // 추가 초상화 데이터 ...
    }

    // 특정 패널 ID의 대사 가져오기
    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
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
        int key = id + portraitIndex;
        if (!portraitData.ContainsKey(key))
        {
            Debug.LogWarning($"Portrait data for key {key} not found. Returning default sprite.");
            return null; // 또는 기본값으로 사용할 스프라이트를 반환
        }
        return portraitData[key];
    }
}
