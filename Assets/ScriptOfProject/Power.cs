using UnityEngine;

public class Power : MonoBehaviour,IInteractable
{
    public Light targetLight1;
    public Light targetLight2;
    public GameObject yamato;
    public GameObject devilTrigger;
    private bool hasTriggered = false;
    public void Interact()
    {
        if (targetLight1 && targetLight2 != null && hasTriggered == false)
        {
            targetLight1.enabled = false;
            targetLight2.enabled = true;
            yamato.SetActive(true);
            devilTrigger.SetActive(false);
            hasTriggered = true;
        }
        else
        {
            Debug.Log("No power.");
        }
    }

}
