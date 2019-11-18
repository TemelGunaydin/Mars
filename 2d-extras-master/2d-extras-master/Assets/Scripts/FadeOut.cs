using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float fadeTime;

    private Image fadeout;
    private Color my_color = Color.black;

    private void OnEnable()
    {
        Time.timeScale = 1;
    }

    private void Awake()
    {
        fadeout = GetComponent<Image>();
    }


    void Start()
    {
        my_color = fadeout.color;
       
    }
    
    void Update()
    {
        

           if(Time.timeSinceLevelLoad < fadeTime)
           {
           
            float alpha = Time.deltaTime / fadeTime;
            my_color.a -= alpha;
            fadeout.color = my_color;

        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
