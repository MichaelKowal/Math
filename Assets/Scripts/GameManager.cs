using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    [SerializeField] public GameObject Inputs;
    [SerializeField] public GameObject ResultsPanel;
    [SerializeField] public GameObject test1;
    [SerializeField] public GameObject test2;
    [SerializeField] public GameObject resultsText;
    [SerializeField] public GameObject answer;
    [SerializeField] public GameObject nextLevelBtn;
    [SerializeField] public GameObject question;
    [SerializeField] public List<GameObject> Levels = new List<GameObject>();
    private int levelCounter = 0;
    private bool kbUp = false;

    private void Update()
    {
        if (TouchScreenKeyboard.visible == true && kbUp == true)
        {
            Inputs.transform.position = new Vector3(Inputs.transform.position.x,
            Inputs.transform.position.y + TouchScreenKeyboard.area.height,
                Inputs.transform.position.z);
            kbUp = false;
        }
        else if (TouchScreenKeyboard.visible == false && kbUp == false)
        {
            Inputs.transform.position = new Vector3(Inputs.transform.position.x,
            Inputs.transform.position.y - TouchScreenKeyboard.area.height,
                Inputs.transform.position.z);
            kbUp = true;
        }

    }

    public void InitGame()
    {
        question.GetComponent<Text>().text = Levels[levelCounter].GetComponent<Level>().Question();
        nextLevelBtn.SetActive(false);
        resultsText.GetComponent<Text>().text = "";
        test1.GetComponent<InputField>().text = "";
        test2.GetComponent<InputField>().text = "";
        answer.GetComponent<InputField>().text = "";
    }

    public void AppendResults(string newAnswer)
    {
        GameObject textBox = ResultsPanel.GetComponentInChildren<Text>().gameObject;
        ResultsPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(
        ResultsPanel.GetComponent<RectTransform>().sizeDelta.x,
             ResultsPanel.GetComponent<RectTransform>().sizeDelta.y
             + 25);
        textBox.GetComponent<RectTransform>().sizeDelta = new Vector2(
        textBox.GetComponent<RectTransform>().sizeDelta.x,
             textBox.GetComponent<RectTransform>().sizeDelta.y
             + 25);
        textBox.GetComponent<Text>().text += "\n" + newAnswer;
    }

    public void NextLevel()
    {
        if (levelCounter == Levels.Count - 1)
            levelCounter = -1;
        question.GetComponent<Text>().text = Levels[++levelCounter].GetComponent<Level>().Question();
        nextLevelBtn.SetActive(false);
        resultsText.GetComponent<Text>().text = "";
        test1.GetComponent<InputField>().text = "";
        test2.GetComponent<InputField>().text = "";
        answer.GetComponent<InputField>().text = "";
    }

    public void Test()
    {
        Levels[levelCounter].GetComponent<Level>().Test();
        test1.GetComponent<InputField>().text = "";
        test2.GetComponent<InputField>().text = "";
    }

    public void Submit()
    {
        Levels[levelCounter].GetComponent<Level>().Submit();
        answer.GetComponent<InputField>().text = "";
    }
}

