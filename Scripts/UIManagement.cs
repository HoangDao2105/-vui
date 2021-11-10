using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public static UIManagement Instance;
    public Text timeText;
    public Text questTxt;
    public DialogNoited dialog;
    public AnswerButton[] answers;
    void Awake()
    {
        MakeSigleTon();
    }


    public void SetTimeTxt(string content)
    {
            timeText.text = content;
 
    }
    public void SetQuestTxt(string content)
    {
        if (questTxt)
        {
            questTxt.text = content;
        }
    }
    public void ShuffleAnswers()
    {
        if (answers != null && answers.Length > 0)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] != null)
                {
                    answers[i].tag = "Untagged";
                }
            }
            int rand = Random.Range(0, answers.Length);
            if (answers[rand])
            {
                answers[rand].tag = "Right Answer";
            }
        }
    }
    public void MakeSigleTon()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
