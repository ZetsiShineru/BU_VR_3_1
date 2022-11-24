using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BadEnd : MonoBehaviour
{
    float timerWait = 25;
    public TMP_Text timeText;
    private void Update()
    {
        timerWait -= Time.deltaTime;
        timeText.text = "" + (int)System.Math.Round(timerWait);
        if(timerWait < 0)
        {
            SceneManager.LoadScene("Design_Room");
        }
    }
}
