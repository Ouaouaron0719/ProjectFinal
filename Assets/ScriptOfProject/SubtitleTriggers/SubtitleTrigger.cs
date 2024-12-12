using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    public string subtitleContent;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public bool allowRepeat = false;
    private bool hasTriggered = false; 

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player") && !hasTriggered)
    //    {
    //        hasTriggered = true; 
    //        FindAnyObjectByType<SubtitleText>().ShowText(subtitleContent);
    //        PlayAudio();
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasTriggered || allowRepeat)
            {
                TriggerSubtitle();
            }
        }
    }

    private void TriggerSubtitle()
    {
        hasTriggered = true;
        FindAnyObjectByType<SubtitleText>().ShowText(subtitleContent);
        PlayAudio();
    }

    private void PlayAudio()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void ResetTrigger()
    {
        hasTriggered = false;
    }
}
