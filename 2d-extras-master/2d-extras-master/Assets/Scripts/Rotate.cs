using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float speed = 5f;
  
    private Timer fastTime;

    private void Start()
    {
        fastTime = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward* speed );      
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            fastTime.isFast = true;
            
            //AudioController.instance.TimeRewardSound(other.transform.position);
            AudioController.instance.TimeRewardSound();          
            gameObject.SetActive(false);
            
        }
    }
}
