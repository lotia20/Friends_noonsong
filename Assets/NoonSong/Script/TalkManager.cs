using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Sprites;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //talkData.Add(1000, new string[]("테스트"));
        //#tutorial 1
        talkData.Add(0, new string[]{"눈송프렌즈를 시작합니다.:0","환영합니다!:1"});
        talkData.Add(1, new string[]{"눈송프렌즈 튜토리얼."});

        //Portrait Data
        //#.1000:눈덩이, 2000: , 3000: , 4000: , 5000: 
        portraitData.Add(0+ 0, portraitArr[0]);
        portraitData.Add(0+ 1, portraitArr[1]);
        portraitData.Add(0+ 2, portraitArr[2]);
        portraitData.Add(0+ 3, portraitArr[3]);



    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)){
            if(!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id %100, talkIndex);
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
