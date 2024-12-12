using UnityEngine;

public class CattyTrigger : MonoBehaviour
{
    private bool hasTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touching");
        if (other.CompareTag("Player") && hasTriggered == false)
        {
            FindAnyObjectByType<SubtitleText>().ShowText("A portrait of a cat, making no sense, anyway let's get closer.");
            hasTriggered = true;
        }
    }
}
