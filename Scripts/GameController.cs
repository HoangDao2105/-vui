using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int rightCount;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
        rightCount = 1;
        CreateQuestion();
        UIManagement.Instance.dialog.Show(false);
        StartCoroutine(CountDown());
    }
    void Update()
    {

    }

    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.Ins.GetRandomQuestion();
        if (qs != null)
        {
            UIManagement.Instance.SetQuestTxt(qs.question);
            string[] wrong = new string[] { qs.AnswerC, qs.AnswerA, qs.AnswerB };
            var temp = UIManagement.Instance.answers;
            if (temp != null && temp.Length > 0)
            {
                UIManagement.Instance.ShuffleAnswers();
                int wronganscount = 0;
                foreach (AnswerButton item in temp)
                {
                    if (string.Compare(item.tag, "Right Answer") == 0)
                    {
                        item.SetAnswerTxt(qs.Right);
                    }
                    else
                    {
                        item.SetAnswerTxt(wrong[wronganscount]);
                        wronganscount++;
                    }
                    item.comp.onClick.RemoveAllListeners();
                    item.comp.onClick.AddListener(() => CheckRightAnswerEvent(item));
                }
            }
        }
    }
    void CheckRightAnswerEvent(AnswerButton rightAnswer)
    {
            if(rightAnswer.CompareTag("Right Answer"))
            {
                if (rightCount == QuestionManager.Ins.questions.Length)
                {
                UIManagement.Instance.dialog.SetDialogContent("Congratulation!!! You won.");
                UIManagement.Instance.dialog.Show(true);
                StopAllCoroutines();
                }
                else
                {
                rightCount++;
                CreateQuestion();
                Debug.Log("Right");
                }
            }
            else
            {
            UIManagement.Instance.dialog.SetDialogContent("Loser!!!");
            UIManagement.Instance.dialog.Show(true);
            Debug.Log("Wrong");
            }
     }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        currentTime--;
        UIManagement.Instance.SetTimeTxt("00:"+currentTime.ToString());
        if (currentTime == 0)
        {
            UIManagement.Instance.dialog.SetDialogContent("Loser!!!");
            UIManagement.Instance.dialog.Show(true);
            StopAllCoroutines();
        }
        StartCoroutine(CountDown());
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
