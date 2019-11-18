using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float player_Speed = 5f;
    Animator anim;
    Rigidbody2D rigid;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {



        if(other.relativeVelocity.y <=0f)
        {
             rigid = other.gameObject.GetComponent<Rigidbody2D>();

              if (rigid != null)
                {

                    StartCoroutine(JumpAnim());
                     Vector2 player_velocity = rigid.velocity;
                    player_velocity.y = player_Speed;
                    rigid.velocity = player_velocity;
                    //AudioController.instance.JumpSound(other.gameObject.transform.position);
                    AudioController.instance.JumpSound();
                }

        }


    }

    IEnumerator JumpAnim()
    {
       
        anim.SetInteger("Number", 0);
        yield return new WaitForSeconds(0.1f);
        anim.SetInteger("Number", 1);
    }



}
