using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameManager manager;
    GameObject scanObject;

    void Update()
    {
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);
    }
}
