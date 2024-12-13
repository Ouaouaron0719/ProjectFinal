using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class VergilFrame : MonoBehaviour,IInteractable
{
    public string yamatoItemName = "Yamato"; 
    public TMP_Text subtitleText;              
    public AudioClip actionAudio;          
    public AudioClip endAudio;             
    public float fadeDuration = 3f;         
    public GameObject endGamePanel;         
    public CanvasGroup fadeCanvasGroup;     

    private bool isGameEnding = false;      
    private AudioSource audioSource;       

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        if (endGamePanel != null) endGamePanel.SetActive(false);
        if (fadeCanvasGroup != null) fadeCanvasGroup.alpha = 0;

    }

    public void Interact()
    {
        if (isGameEnding) return; 


        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();
        if (backpackManager != null && backpackManager.GetCurrentItemName() == yamatoItemName)
        {
            StartEndGameSequence();
            FindObjectOfType<SubtitleText>().ShowText("Yamato! Judgment Cut!!!", 12f);
        }
        else
        {
            FindObjectOfType<SubtitleText>().ShowText("Are you forgetting somthing?", 2f);
        }
    }

    //private void ShowSubtitle(string message)
    //{
    //    if (subtitleText != null)
    //    {
    //        subtitleText.text = message;
    //        subtitleText.gameObject.SetActive(true);

    //        Invoke(nameof(HideSubtitle), 3f);
    //    }
    //}

    //private void HideSubtitle()
    //{
    //    if (subtitleText != null)
    //    {
    //        subtitleText.gameObject.SetActive(false);
    //    }
    //}

    private void StartEndGameSequence()
    {
        isGameEnding = true;


        if (actionAudio != null)
        {
            audioSource.clip = actionAudio;
            audioSource.Play();
        }


        StartCoroutine(FadeToBlack());
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            if (fadeCanvasGroup != null)
            {
                fadeCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            }
            yield return null;
        }

        Time.timeScale = 0f; 

        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
        }

        if (endAudio != null)
        {
            audioSource.clip = endAudio;
            audioSource.Play();
        }
    }
}
