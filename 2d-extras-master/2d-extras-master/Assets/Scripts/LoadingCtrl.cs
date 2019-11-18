using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingCtrl : MonoBehaviour
{


    
    public GameObject loadingUI; 
    public Slider slider;

    AsyncOperation test1;

   
    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadNextLevel(levelName));
    }

    IEnumerator LoadNextLevel(string levelName)
    {
       
        loadingUI.SetActive(true);
        test1 = SceneManager.LoadSceneAsync(levelName);        


        while(test1.isDone == false)
        {
            slider.value = test1.progress;
            if(test1.progress == 0.9f)
            {
                slider.value = 1f;
                test1.allowSceneActivation = true;
            }
            yield return null;
        }
       
    }

}
