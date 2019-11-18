
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance = null;
    public Audio my_audio;

    //deneme amaclı

    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        source = GetComponent<AudioSource>();
    }


    void Start()
    {
        
    }

    /*
    public void JumpSound(Vector3 playerPosition)
    {
        AudioSource.PlayClipAtPoint(my_audio.jumpSound, playerPosition);
        
    }
    */

    public void JumpSound()
    {
        source.clip = my_audio.jumpSound;
        source.Play();
             
    }


    /*
    public void ExplosionSound(Vector3 playerPosition)
    {
        AudioSource.PlayClipAtPoint(my_audio.explosionSound, playerPosition);
    }
    */

    public void ExplosionSound()
    {
        source.clip = my_audio.explosionSound;
        source.Play();
    }

    /*
    public void PlayerDiedSound(Vector3 playerPosition)
    {
        AudioSource.PlayClipAtPoint(my_audio.playerdiedSound, playerPosition);
    }
    */

    public void PlayerDiedSound()
    {
        source.clip = my_audio.playerdiedSound;
        source.Play();

    }

    /*
    public void TimeRewardSound(Vector3 playerPosition)
    {
        AudioSource.PlayClipAtPoint(my_audio.timeRewardSound, playerPosition);
    }
    */

    public void TimeRewardSound()
    {
        source.clip = my_audio.timeRewardSound;
        source.Play();

    }

}


[System.Serializable]
public class Audio
{
    public AudioClip jumpSound;
    public AudioClip explosionSound;
    public AudioClip playerdiedSound;
    public AudioClip timeRewardSound;
}