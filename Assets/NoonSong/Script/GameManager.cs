using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
//using DarkTonic.MasterAudio;

public class GameManager : MonoBehaviour
{
    public Animator TutorialAnim;
    public SpriteRenderer playerSprite;
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Image portaritImg;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;



    float delay;
    float animSpeed = 1f;

    void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null){
            isAction = false;
            talkIndex = 0; 
            return;
        }

        if(isNPC){
            talkText.text = talkData.Split(":")[0];

            portaritImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portaritImg.color = new Color(1,1,1,1);
        }
        else{
            talkText.text = talkData;
            portaritImg.color = new Color(1,1,1,0);
        }

        isAction = true;
        talkIndex++;
    }
}
