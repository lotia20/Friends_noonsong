using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//using Sirenix.OdinInspector;
//using DarkTonic.MasterAudio;
//using DG.Tweening;
using TMPro;
using UnityEditor.Build.Content;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public TalkManager talkManager;
    public RectTransform talkPanel;
    public Image talkProtraitImage;
    public Text talkName;
    public Text talkContents;
    public GameObject talkEndCursor;
    void Start()
    {
        Invoke("StartTutorialTalk", 2f);
    }

    void StartTutorialTalk()
    {
        //gameManager.isEventLoading = true;
        //gameManager.isStopTime = true;
        talkManager.GetTalk(0, 0);
        UIDisplay("Talk",true);
    }

    public void UIDisplay(string uiSet, bool isDisplay)
    {
        // if (uiSet == "Talk"){
        //     talkPanel.DOKILL();
        //     talkPanel.DoAnchorPosY(isDisplay ? 400 : 1200, 0.5f).SetEase(Ease.OutQuad).SetDisplay(1);
        // }
    }
}
