using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdDemand : MonoBehaviour
{

    public bool timedBanner;

    public float timeduration;



    void Start()
    {

        AdCtrl.instance.ShowBanner();
    }



    private void OnDisable()
    {
        if(!timedBanner)
        {
            AdCtrl.instance.HideBanner();
        }

        else
        {
            AdCtrl.instance.HideBanner(timeduration);
        }
    }

}
