using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    public string subtitleContent;
    public AudioClip audioClip;
    public AudioSource audioSource;

    private bool hasTriggered = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; 
            FindAnyObjectByType<SubtitleText>().ShowText(subtitleContent);
            PlayAudio();
        }
    }
    private void PlayAudio()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned for " + gameObject.name);
        }
    }
}
