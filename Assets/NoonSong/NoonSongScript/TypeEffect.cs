using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public GameObject EndCursor;
    public int CharPerSeconds;
    Text msgtext;
    int index;
    float interval;
    bool isAnim;

    private void Awake()
    {
        msgtext = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        if(isAnim){
            msgtext.text =targetMsg;
            CancelInvoke();
            
            EffectEnd();
        }else{
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgtext.text = "";
        index = 0;

        EndCursor.SetActive(false);
        isAnim = true;

        //애니메이션 속도
        interval = 1.0f/CharPerSeconds;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if(msgtext.text == targetMsg){
            EffectEnd();
            return;
        }
        
        msgtext.text += targetMsg[index];
        index++;
        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}
