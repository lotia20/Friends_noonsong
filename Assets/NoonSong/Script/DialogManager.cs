using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(0, new string[] { "앗! 여기가 숙명여대인가요?", "안녕? 너도 여기서 무얼 하고 있어?" });

        talkData.Add(100, new string[] {"골드메탈 뇌 뜯어오고 싶다.", "아니면 복제라두?"});

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
}
