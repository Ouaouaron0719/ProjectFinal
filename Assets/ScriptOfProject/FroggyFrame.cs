using UnityEngine;

public class FroggyFrame : MonoBehaviour,IInteractable
{
    [Header("Light to Disable")]
    public Light targetLight;
    private bool hasTriggered = false;
    public void Interact()
    {
        if (targetLight != null && hasTriggered == false)
        {
            targetLight.enabled = false;
            FindAnyObjectByType<SubtitleText>().ShowText("Frog King: There's something above the tunnel.");
            hasTriggered = true;
        }
        else
        {
            Debug.Log("No light assigned to FroggyFrame.");
        }
    }
}
