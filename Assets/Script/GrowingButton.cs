using UnityEngine;

public class GrowingButton : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        transform.localScale *= 1.1f;
    }
}
