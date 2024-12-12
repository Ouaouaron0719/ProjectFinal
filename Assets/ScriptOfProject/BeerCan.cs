using UnityEngine;

public class BeerCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();

        if (backpackManager != null)
        {
            backpackManager.CollectItem(gameObject);
            gameObject.SetActive(false); 
            Debug.Log("Beer added to backpack!");
            FindAnyObjectByType<SubtitleText>().ShowText("Damn, we got a beer!", 3f);
        }
        else
        {
            Debug.LogWarning("BackpackManager not found in the scene!");
        }
    }
}
