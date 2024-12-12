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
        }
        else
        {
            Debug.LogWarning("BackpackManager not found in the scene!");
        }
    }
}
