using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public GameObject talkPanel;
    
    public void Action(GameObject scanObj)
    {
        if (isAction) {
            isAction = false;
            
        }
        else{
            isAction = true;
            scanObject = scanObj;
            talkText.text = "스캔완료했습니다." +scanObject.name + "이라고 합니다.";
        }
        
        talkPanel.SetActive(isAction);
    }
}
