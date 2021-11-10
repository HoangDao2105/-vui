using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Ins;
    public QuestionData[] questions;
    List<QuestionData> l_question;
    QuestionData m_question;

    public QuestionData Question { get => m_question; set => m_question = value; }
    void Awake()
    {
        l_question = questions.ToList();
        makeSingleTon();
      
    }
    public QuestionData GetRandomQuestion()
    {
        if (l_question != null && l_question.Count > 0)
        {
            int rand = Random.Range(0, l_question.Count);
            m_question = l_question[rand];
            l_question.RemoveAt(rand);
        }
        return m_question;
    }
    public void makeSingleTon()
    {
        if (Ins == null)
        {
            Ins = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
