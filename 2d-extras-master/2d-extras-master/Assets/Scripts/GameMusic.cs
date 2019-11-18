using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private AudioSource my_audio;

    private void Awake()
    {

        my_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        DataCtrl.instance.LoadData();
    }

    private void Update()
    {
        my_audio.volume = DataCtrl.instance.data.volume;
    }


}
