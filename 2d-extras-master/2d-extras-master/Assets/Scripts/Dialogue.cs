using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue : MonoBehaviour
{

    public Text hero_name, player_name;
    public TextMeshProUGUI hero_area, player_area;
    public Animator anim;
    public GameObject continueButton;
    public GameObject startButton;


    public DialogueData data;
    private int index = 0;
    private AudioSource my_audio;

   

    private void Start()
    {
        my_audio = GetComponent<AudioSource>();
        StartCoroutine("StartDialogue");
    }

    private void Update()
    {
        if(hero_area.text == data.sentences[index] || player_area.text == data.sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator StartDialogue()
    {

        anim.SetBool("Open", true);
        hero_area.text = "";
        player_area.text = "";

        hero_name.text = data.hero_name;
        player_name.text = data.player_name;

        foreach (char letter in data.sentences[index].ToCharArray())
        {
            if(index % 2 == 0)
            {
                hero_area.text += letter;
                yield return null;
            }
            
            if(index == 1 || index % 2 !=0)
            {
                player_area.text += letter;
                yield return null;
            }
        }


    }

    public void NextSentence()
    {

        my_audio.Play();
        continueButton.SetActive(false);

        if (index < data.sentences.Length -1)
        {
            index++;
            hero_area.text = "";
            player_area.text = "";
            StopAllCoroutines();
            StartCoroutine("StartDialogue");

        }
        else
        {
            hero_area.text = "";
            player_area.text = "";
            anim.SetBool("Open", false);
            continueButton.SetActive(false);
            startButton.SetActive(true);
        }
    }

    


}

[System.Serializable]
public class DialogueData
{
    public string hero_name, player_name;
    [TextArea(3,10)]
    public string[] sentences;
}