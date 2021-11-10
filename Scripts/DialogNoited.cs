using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogNoited : MonoBehaviour
{
    public Text dialogContent;
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow); 
    }
    public void SetDialogContent(string Content)
    {

            dialogContent.text = Content;
        
    }
    
}
