using UnityEngine;

public class CattyFrame : MonoBehaviour, IInteractable
{
    [Header("Light to Disable")]
    public Light targetLight;
    private bool hasTriggered = false;
    public void Interact()
    {
        if (targetLight != null && hasTriggered == false)
        {
            targetLight.enabled = false;
            FindAnyObjectByType<SubtitleText>().ShowText("I am as confused as you are, but you seem to have gained its ability, you can try pressing 'Q'.");
            hasTriggered = true;
        }
        else
        {
            Debug.Log("No light assigned to CattyFrame.");
        }
    }
}
