using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public static Spikes instance = null;




    public GameObject explosionPreFab;


    private GameObject player;


    private void Awake()
    {
        if (instance == null)
            instance = this;        
    }



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Explosion");
        }
    }

     IEnumerator Explosion()
    {
        Instantiate(explosionPreFab, player.transform.position, Quaternion.identity);
        //AudioController.instance.ExplosionSound(player.transform.position);
        AudioController.instance.ExplosionSound();
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        Player playerScript = player.GetComponent<Player>();
        playerScript.PlayerDied();
    }

    public void StartExplosion()
    {
        StartCoroutine("Explosion");

    }


}
