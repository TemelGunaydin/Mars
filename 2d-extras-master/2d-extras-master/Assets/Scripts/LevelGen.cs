using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{

    public static LevelGen instance = null;

    public GameObject tiles;
    public GameObject spikes_tiles;
    public GameObject half_tiles;
    public GameObject speed_tiles;



    [HideInInspector] public float quarterGravityHeight;
    [HideInInspector] public float doubleGravityHeight;

    private int rewardCounter=1;

    private bool doubleGravity;
    private bool quarterGravity;

    private float screenWidth;   
    private Vector2 pos = new Vector2();
    private Vector2 spikePos = new Vector2();

    private void Awake()
    {
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }


    private void Start()
    {
       
        if(instance ==null)
        {
            instance = this;
        }


       
            for (int i = 0; i < 25; i++)
            {
                pos.x = Random.Range(-screenWidth + 2, screenWidth - 2);
                pos.y += Random.Range(3, 10);

                if (i > 7)

                    {

                        while (rewardCounter >0)
                        {
                            Instantiate(speed_tiles, new Vector2(Random.Range(-screenWidth + 2, screenWidth - 2), pos.y+4), Quaternion.identity);
                            --rewardCounter;
                        }

                    }
            Instantiate(tiles, pos, Quaternion.identity);
        }

        ResetRewardCounter();
        quarterGravity = true;
        

            for (int i = 0; i < 30; i++)
            {
                pos.x = Random.Range(-screenWidth + 5, screenWidth - 5);
                pos.y += 4;
                Instantiate(half_tiles, pos, Quaternion.identity);
                if (i > 7)

                    {

                        while (rewardCounter > 0)
                        {
                            Instantiate(speed_tiles, new Vector2(Random.Range(-screenWidth + 2, screenWidth - 2), pos.y + 4), Quaternion.identity);
                            --rewardCounter;
                        }
                    }
                    
                if (quarterGravity)
                        {
                            quarterGravityHeight = pos.y;               
                            quarterGravity = false;
                        }

                }

        ResetRewardCounter();
        doubleGravity = true;
        spikePos.y = pos.y;

            for (int i = 0; i < 40; i++)
            {
                pos.x = Random.Range(-screenWidth + 5, screenWidth - 5);
                spikePos.x = Random.Range(-screenWidth + 2, screenWidth - 2);
                pos.y += 4;
                spikePos.y += 8;
                Instantiate(spikes_tiles, spikePos, Quaternion.identity);
                Instantiate(half_tiles, pos, Quaternion.identity);

                if (i > 7)
                    {
                        while (rewardCounter > 0)
                            {
                                Instantiate(speed_tiles, new Vector2(Random.Range(-screenWidth + 2, screenWidth - 2), pos.y + 4), Quaternion.identity);
                                --rewardCounter;
                            }
                     }
            
                if (doubleGravity)
                     {
                        doubleGravityHeight = pos.y;
                        doubleGravity = false;
                     }

            }


    }


    private void ResetRewardCounter()
    {
        rewardCounter = 1;
    }

}
