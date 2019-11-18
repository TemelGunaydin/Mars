using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class Timer : MonoBehaviour
{

    

    [HideInInspector] public float counter;
   
    private Text time;
    private float countDown = 5f;
    private int fontSize;
    private Color fontColor;
    private Player player;
    [HideInInspector] public bool isFast;


  


    private void Awake()
    {
        time = GetComponent<Text>();
        fontSize = time.fontSize;
        fontColor = time.color;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

      
    }

    private void Update()
    {
        counter += Time.deltaTime;
        time.text = counter.ToString("0.0.0");
        if(isFast && !player.isDead)
        {
            StartCoroutine("TimeReward");
        }

        if(player.isDead)
        {
           
            DataCtrl.instance.data.highScore = counter;
            DataCtrl.instance.SaveData();
            
        }

              

    }




    IEnumerator TimeReward()
    {
         while (isFast && countDown >= 0)
        {
            
            time.color = Color.red;
            time.fontSize = 240;
            counter += 3f;
            countDown -= Time.deltaTime;
            yield return new WaitForSeconds(1f);

        }

        isFast = false;
        time.fontSize = fontSize;
        time.color = fontColor;
        countDown = 5f;
        
    }


   

  

}

