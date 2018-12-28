using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level8 : Level
{
    // 2x / y
    public override string Question()
    {
        return "12, 6 = 4\n15, 3 = ?";
    }

    public override void Test()
    {
        GameObject test1 = GameManager.instance.test1;
        GameObject test2 = GameManager.instance.test2;
        int i, j, k;
        if (!Int32.TryParse(test1.GetComponent<InputField>().text, out i))
        {
            i = 0;
        }
        if (!Int32.TryParse(test2.GetComponent<InputField>().text, out j))
        {
            j = 0;
        }
        string result;
        if (i == 15 && j == 3)
        {
            result = i + ", " + j + " = ?";
        }
        else
        {
            try
            {
                k = 2 * i / j;
                result = i + ", " + j + " = " + k;
            }
            catch (DivideByZeroException e)
            {
                result = "null";
            }
        }
        GameManager.instance.AppendResults(result);
    }

    public override void Submit()
    {
        GameObject answer = GameManager.instance.answer;
        GameObject result = GameManager.instance.resultsText;
        if (answer.GetComponent<InputField>().text.Equals("52"))
        {
            result.GetComponent<Text>().text = "Success!";
            GameManager.instance.nextLevelBtn.SetActive(true);
        }
        else
            result.GetComponent<Text>().text = "Try Again";
    }
}
