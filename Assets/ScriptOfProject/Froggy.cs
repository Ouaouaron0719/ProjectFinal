using UnityEngine;

public class Froggy : MonoBehaviour,IInteractable
{
    public Transform cameraTransform;  
    public Transform handTransform;   
    public Transform frogTransform;    
    public AudioClip useAudio;         

    private bool isUsing = false;     
    private Vector3 targetFrogPosition = new Vector3(0f, -0.3f, 0.5f); 
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

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
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && IsCurrentItem())
        {
            if (!isUsing)
            {
                StartUsingFrog();
            }
            else
            {
                StopUsingFrog();
            }
        }
    }
    private bool IsCurrentItem()
    {
        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();
        return backpackManager != null && backpackManager.GetCurrentItem() == gameObject;
    }
    private void StartUsingFrog()
    {
        isUsing = true;

        frogTransform.SetParent(cameraTransform);
        frogTransform.localPosition = targetFrogPosition;
        frogTransform.localRotation = Quaternion.identity;

        if (useAudio != null)
        {
            audioSource.clip = useAudio;
            audioSource.Play();
        }

        FindObjectOfType<SubtitleText>().ShowText("Ewww....", 2f);
    }
    private void StopUsingFrog()
    {
        isUsing = false;

        frogTransform.SetParent(handTransform);
        frogTransform.localPosition = Vector3.zero;
        frogTransform.localRotation = Quaternion.identity;
    }
}
