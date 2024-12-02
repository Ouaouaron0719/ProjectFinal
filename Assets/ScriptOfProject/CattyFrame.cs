using UnityEngine;

public class CattyFrame : MonoBehaviour, IInteractable
{
    [Header("Light to Disable")]
    public Light targetLight;
    public void Interact()
    {
        Debug.Log("CattyFrame interacted with!");

        if (targetLight != null)
        {
            targetLight.enabled = false; 
            Debug.Log($"{targetLight.name} has been turned off.");
        }
        else
        {
            Debug.LogWarning("No light assigned to CattyFrame.");
        }
    }
}
