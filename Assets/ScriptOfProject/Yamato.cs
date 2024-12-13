using UnityEngine;

public class Yamato : MonoBehaviour,IInteractable
{
    public GameObject scabbard;
    public void Interact()
    {
        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();
        if (backpackManager != null)
        {
            backpackManager.CollectItem(gameObject);
            gameObject.SetActive(false);
            scabbard.SetActive(false);
            Debug.Log("Yamato added to backpack!");
            FindObjectOfType<SubtitleText>().ShowText("Damn, we got the real power!");
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
