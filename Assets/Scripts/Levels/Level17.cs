﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level17 : Level
{
    // 3x - y^2
    public override string Question()
    {
        return "16, 11 = 169\n31, 9 = ?";
    }

    public override void Test()
    {
        GameObject test1 = GameManager.instance.test1;
        GameObject test2 = GameManager.instance.test2;
        int i, j;
        if (!Int32.TryParse(test1.GetComponent<InputField>().text, out i))
        {
            i = 0;
        }
        if (!Int32.TryParse(test2.GetComponent<InputField>().text, out j))
        {
            j = 0;
        }
        string result;
        if (i == 31 && j == 9)
        {
            result = i + ", " + j + " = ?";
        }
        else
        {
            int k = 3 * i + j * j;
            result = i + ", " + j + " = " + k;
        }
        GameManager.instance.AppendResults(result);

    }

    public override void Submit()
    {
        GameObject answer = GameManager.instance.answer;
        GameObject result = GameManager.instance.resultsText;
        if (answer.GetComponent<InputField>().text.Equals("12"))
        {
            result.GetComponent<Text>().text = "Success!";
            GameManager.instance.nextLevelBtn.SetActive(true);
        }
        else
            result.GetComponent<Text>().text = "Try Again";
    }
}
