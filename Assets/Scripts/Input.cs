using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    public void Click()
    {
        GameObject inputField = GameObject.Find("InputBox");
        string Symbol = gameObject.GetComponentInChildren<Text>().text;
        inputField.GetComponent<Text>().text += Symbol;
    }
}
