using UnityEngine;

public class PickUpAndDestory : MonoBehaviour, IInteractable
{
    public GameObject otherObjectToDestory;
    public void Interact()
    {
        Destroy(otherObjectToDestory);
        Destroy(gameObject);
    }

}
