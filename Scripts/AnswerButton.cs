using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswerButton : MonoBehaviour
{
    public Text answerTxt;
    public Button comp;
    public void SetAnswerTxt(string content)
    {
        if (answerTxt)
        {
            answerTxt.text = content;
        }
    }
}
