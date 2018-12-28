﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level19 : Level
{
    // (y - 7)x
    public override string Question()
    {
        return "23, 13 = 138\n15, 11 = ?";
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
        if (i == 15 && j == 11)
        {
            result = i + ", " + j + " = ?";
        }
        else
        {
            int k = (j - 7) * i;
            result = i + ", " + j + " = " + k;
        }
        GameManager.instance.AppendResults(result);
    }

    public override void Submit()
    {
        GameObject answer = GameManager.instance.answer;
        GameObject result = GameManager.instance.resultsText;
        if (answer.GetComponent<InputField>().text.Equals("60"))
        {
            result.GetComponent<Text>().text = "Success!";
            GameManager.instance.nextLevelBtn.SetActive(true);
        }
        else
            result.GetComponent<Text>().text = "Try Again";
    }
}
