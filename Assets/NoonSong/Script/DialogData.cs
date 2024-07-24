using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogData : MonoBehaviour
{
    public Text talkText;
    public DialogManager dialogManager;
    public GameObject scanGPS;
    public GameObject talkPanel;
    public bool isActivated;
    //public int talkIndex;

    public void Action(GameObject scanPos)
    {
        if (isActivated)
        {
            isActivated = false;
        }
        else
        {
            isActivated = true;
            scanGPS = scanPos;
            //ObjData objData = scanObject.GetComponent<ObjData>();
            //Talk(objData.id, objData.isNpc);
        }

        talkPanel.SetActive(isActivated);
        
        
    }

    void Talk(int id, bool isPlace)
    {
        string talkData = dialogManager.GetTalk(0, 0);
        talkText.text = talkData;
    }
    
}
