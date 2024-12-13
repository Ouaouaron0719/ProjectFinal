using UnityEngine;

public class Froggy : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();
        if (backpackManager != null)
        {
            backpackManager.CollectItem(gameObject);
            gameObject.SetActive(false);
            Debug.Log("Froggy added to backpack!");
            FindObjectOfType<SubtitleText>().ShowText("Damn, we got an Ouaouaron! I think we should go back to where you were born. ");
        }
        else
        {
            Debug.LogWarning("BackpackManager not found in the scene!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
