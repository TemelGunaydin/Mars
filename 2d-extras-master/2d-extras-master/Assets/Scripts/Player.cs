using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float player_Speed =5f;
    public GameObject gameOverUI;
    public Joystick joyStick;

    [HideInInspector]
    public bool isDead;

    private Rigidbody2D rigid;
    private float moveInput;
    private Vector2 gravity;
    private float blowTime = 5f;
    private float counter=0;
    private SpriteRenderer sprite;
    private Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        moveInput = joyStick.Horizontal;


       // moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput<0)
        {
            sprite.flipX = true;
        }

        if (moveInput > 0)
        {
            sprite.flipX = false;
        }

        if (counter < blowTime && moveInput == 0)
        {
            counter += Time.deltaTime;
            if(counter >= 5f)
            {
                Spikes.instance.StartExplosion();
            }

        }
        else if(moveInput!=0)
        {
            counter = 0f;
        }



            if (transform.position.y >=  LevelGen.instance.quarterGravityHeight)
        {
            Physics2D.gravity = new Vector2(0, -75);
            
        }

        if (transform.position.y >= LevelGen.instance.doubleGravityHeight)
        {
            Physics2D.gravity = new Vector2(0, -100);
        }



    }

   
    private void FixedUpdate()
    {
        Vector2 player_velocity = rigid.velocity;
        player_velocity.x = moveInput * player_Speed ;
        rigid.velocity = player_velocity;
    }



    public void PlayerDied()
    {
        isDead = true;
        AdCtrl.instance.ShowInter();
        GameisOver();
        //AudioController.instance.PlayerDiedSound(transform.position);
        AudioController.instance.PlayerDiedSound();
        //Destroy(gameObject,3f);
    }

    public void GameisOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        //Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        Physics2D.gravity = new Vector2(0, -50);
        //Time.timeScale = 1f;

    }



}
