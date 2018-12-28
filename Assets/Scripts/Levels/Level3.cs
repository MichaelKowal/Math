using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3 : Level
{
    // y / x + x
    public override string Question()
    {
        return "5, 20 = 9\n7, 28 = ?";
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
        if (i == 7 && j == 28)
        {
            result = i + ", " + j + " = ?";
        }
        else
        {
            try
            {
                k = j / i + i;
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
        if (answer.GetComponent<InputField>().text.Equals("11"))
        {
            result.GetComponent<Text>().text = "Success!";
            GameManager.instance.nextLevelBtn.SetActive(true);
        }
        else
            result.GetComponent<Text>().text = "Try Again";
    }
}
