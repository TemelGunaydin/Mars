using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text counter_outside;
    public Text sentence_outside; // HighScore altındaki Text

    private Text highScore_local;
    private Timer timer;
    private float value;


    private void Awake()
    {
        highScore_local = GetComponent<Text>();
        timer = counter_outside.GetComponent<Timer>();
        
    }


    private void Start()
    {
        if(timer.counter >=60)
        {
            value = timer.counter / 60;
            highScore_local.text = String.Format("{0:F2}", value);
            sentence_outside.text = "Space Minutes Survied";
        }
        else
        {
            highScore_local.text = counter_outside.text.ToString();
            sentence_outside.text = "Space Seconds Survived";
        }
    }




}
