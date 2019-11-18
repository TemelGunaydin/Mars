using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float speed = 5f;

    private float screenWidth;
    private Vector3 vel;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    private void LateUpdate()
    {
        if(player.position.y > transform.position.y)
        {
            Vector3 nextPos = new Vector3(Mathf.Clamp(player.position.x, -screenWidth, screenWidth), player.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref vel ,speed * Time.deltaTime);

        }

        else
        {
            Vector3 nextPos = new Vector3(Mathf.Clamp(player.position.x, -screenWidth, screenWidth), transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref vel, speed * Time.deltaTime);

        }



    }


}
