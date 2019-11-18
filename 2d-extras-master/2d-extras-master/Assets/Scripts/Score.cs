using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private Text score;
    private float time_score;
    private float highScore;
   


    private void Awake()
    {
        score = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

        DataCtrl.instance.LoadData();

        time_score = DataCtrl.instance.data.highScore;
        //highScore_min = DataCtrl.instance.data.highScore_min;
        //highScore_sec = DataCtrl.instance.data.highScore_sec;


        highScore = DataCtrl.instance.data.highScore_min;


        /*
        if (time_score >= 60 && time_score/60 > highScore_min)
        {
            float value = time_score / 60;
            score.text = System.String.Format("{0:F2}", value) + "\nSpace Minutes Survived";
            DataCtrl.instance.data.highScore_min = value;

        }

        if(time_score < 60 && time_score > highScore_sec)

        {
            score.text = time_score.ToString()+ "\nSpace Seconds Survived";
            DataCtrl.instance.data.highScore_sec = time_score;
        }

       else
        {
            if(time_score >= 60 && time_score/60 <highScore_min )
            {
                highScore_min = DataCtrl.instance.data.highScore_min;
                score.text = System.String.Format("{0:F2}", highScore_min) + "\nSpace Minutes Survived";
            }
            if(time_score< 60 && time_score < highScore_sec)
            {
                highScore_sec = DataCtrl.instance.data.highScore_sec;
                score.text = highScore_sec.ToString() + "\nSpace Seconds Survived";

            }
        }

         */


        if (time_score >= 60 && time_score > highScore)
        {
            float value = time_score / 60;
            score.text = System.String.Format("{0:F2}", value) + "\nSpace Minutes Survived";
            DataCtrl.instance.data.highScore_min = time_score;

        }

        if (time_score < 60 && time_score > highScore)

        {
            score.text = System.String.Format("{0:F2}", time_score) + "\nSpace Seconds Survived";
            DataCtrl.instance.data.highScore_min = time_score;
        }

        else
        {
            if (time_score >= 60 && time_score < highScore)
            {
                highScore = DataCtrl.instance.data.highScore_min;
                score.text = System.String.Format("{0:F2}", highScore /60) + "\nSpace Minutes Survived";
            }
            if (time_score < 60 && time_score < highScore && highScore >=60)
            {
                highScore = DataCtrl.instance.data.highScore_min;
                score.text = System.String.Format("{0:F2}", highScore / 60) + "\nSpace Minutes Survived";

            }

            if(time_score < 60 && time_score < highScore && highScore < 60)
            {
                highScore = DataCtrl.instance.data.highScore_min;
                score.text = System.String.Format("{0:F2}", highScore) + "\nSpace Seconds Survived";

            }


        }

    }

    private void OnEnable()
    {
        Time.timeScale = 1;
        DataCtrl.instance.LoadData();
    }

    private void OnDisable()
    {
        //DataCtrl.instance.data.highScore_min =highScore;
        //DataCtrl.instance.data.highScore_sec = highScore;


        DataCtrl.instance.SaveData();
        //DataCtrl.instance.LoadData();


    }
}
