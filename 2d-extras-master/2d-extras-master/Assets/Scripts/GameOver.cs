using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Animator anim;

    public Player player;



    private void Update()
    {
        if(player.isDead)
        {
            anim.SetBool("Game", true);
            anim.SetBool("HighScore", true);
        }
    }

  



}
