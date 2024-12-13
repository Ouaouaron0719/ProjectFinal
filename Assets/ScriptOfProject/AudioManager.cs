using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip bgm;

    private void Start()
    {
        PlayBGM(); 
    }
    public void PlayBGM()
    {
        if (bgmSource.clip != bgm)
        {
            bgmSource.clip = bgm;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }
}
