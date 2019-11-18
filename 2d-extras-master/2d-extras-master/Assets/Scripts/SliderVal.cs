using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVal : MonoBehaviour
{
    private Slider volume;
    public GameObject audio;


    private void Awake()
    {
        volume = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(DataCtrl.instance.data.volume);
        volume.value = DataCtrl.instance.data.volume;
    }

    private void Update()
    {
        audio.GetComponent<AudioSource>().volume = volume.value;
    }



    private void OnEnable()
    {
        Time.timeScale = 1;
        DataCtrl.instance.LoadData();
    }

    private void OnDisable()
    {
        DataCtrl.instance.data.volume = volume.value;
        DataCtrl.instance.SaveData();
        DataCtrl.instance.LoadData();

        volume.value = DataCtrl.instance.data.volume;
     //   Debug.Log("loaded " + DataCtrl.instance.data.volume);

    }
}
