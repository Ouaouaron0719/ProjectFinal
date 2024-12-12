using System.Collections.Generic;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    private List<GameObject> collectedItems = new List<GameObject>();

    private int currentIndex = -1;

    public Transform itemDisplayPosition;

    private GameObject currentItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && collectedItems.Count > 0)
        {
            SwitchItem();
        }

        if (Input.GetMouseButtonDown(1) && currentItem != null)
        {
            UseItem();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableItem"))
        {
            CollectItem(other.gameObject);
        }
    }
    public void CollectItem(GameObject item)
    {
        collectedItems.Add(item);
        item.SetActive(false); 
        Debug.Log("Collected: " + item.name);

        if (collectedItems.Count == 1)
        {
            currentIndex = 0;
            DisplayItem();
        }
    }

    private void SwitchItem()
    {
        if (currentItem != null)
        {
            currentItem.SetActive(false);
        }

        currentIndex = (currentIndex + 1) % collectedItems.Count;

        DisplayItem();
    }

    private void DisplayItem()
    {
        if (currentIndex >= 0 && currentIndex < collectedItems.Count)
        {
            currentItem = collectedItems[currentIndex];
            currentItem.SetActive(true);
            currentItem.transform.position = itemDisplayPosition.position;
            currentItem.transform.rotation = itemDisplayPosition.rotation;
            currentItem.transform.SetParent(itemDisplayPosition); 
        }
    }
    private void UseItem()
    {
        Debug.Log("Using item: " + currentItem.name);
    }
}
