using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteradForMenu : MonoBehaviour
{

    public float duration = 5f;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine("WaitForAds", duration);
        }
    }

    IEnumerator WaitForAds(float duration)
    {
        yield return new WaitForSeconds(5f);
        AdCtrl.instance.ShowInter();
    }

}
