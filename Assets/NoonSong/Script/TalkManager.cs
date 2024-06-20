using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Sprites;

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
        talkData.Add(0, new string[] { "숙명여대에 갓 입학한 새송이는 학교 탐방을 오게 되었다!:0", "그런데 어쩌지? 학교가 너무 복잡해!:0" });
        talkData.Add(1, new string[] { "[학교가 처음이라 막막하네...]" });
        talkData.Add(2, new string[] { "안녕, 친구야! 혹시 무슨 고민 있어?", "아하, 아직 학교가 처음이라 모르는 게 많다고? 음... 어디보자~", "그렇지! 숙명여대라면 역시 눈송이! 그 애가 널 도와줄 수 있을 거야!", "같이 학교를 돌아다니면서 눈송이가 어디에 있는지 찾아보자!" });

        // Portrait Data
        portraitData.Add(0 + 0, portraitArr[0]); // 나레이션 초상화
        portraitData.Add(0 + 1, portraitArr[1]); // 나레이션 초상화
        portraitData.Add(1000 + 0, portraitArr[2]); // 유저 초상화
        portraitData.Add(2000 + 0, portraitArr[3]); // 눈덩이 초상화
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
            else
                return GetTalk(id - id % 10, talkIndex);
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
