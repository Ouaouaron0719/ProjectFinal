using System.Collections;
using UnityEngine;

public class BeerCan : MonoBehaviour, IInteractable
{
    public Transform cameraTransform;
    public Transform handTransform;
    public Transform beerCanTransform;
    public float liftDuration = 0.5f;
    public AudioClip drinkSound;        
    public AudioSource audioSource;


    private bool isUsing = false;
    private Vector3 targetBeerPosition = new Vector3(0f, -0.3f, 0.5f);
    private float targetXRotation = -90f;

    public void Interact()
    {
        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();
        if (backpackManager != null)
        {
            backpackManager.CollectItem(gameObject);
            gameObject.SetActive(false);
            Debug.Log("Beer added to backpack!");
            FindObjectOfType<SubtitleText>().ShowText("Damn, we got a beer!", 3f);
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
                StartUsingBeer();
            }
            else
            {
                StopUsingBeer();
            }
        }

    }

    private bool IsCurrentItem()
    {
        BackpackManager backpackManager = FindObjectOfType<BackpackManager>();
        return backpackManager != null && backpackManager.GetCurrentItem() == gameObject;
    }

    private void StartUsingBeer()
    {
        isUsing = true;

        if (drinkSound != null && audioSource != null)
        {
            audioSource.clip = drinkSound;
            audioSource.Play();
        }

        beerCanTransform.SetParent(cameraTransform);
        beerCanTransform.localPosition = targetBeerPosition;
        beerCanTransform.localRotation = Quaternion.Euler(0f, 90f, 0f);

        StartCoroutine(SmoothCameraRotation(cameraTransform.eulerAngles.x, targetXRotation));
    }

    private void StopUsingBeer()
    {
        isUsing = false;

        beerCanTransform.SetParent(handTransform);
        beerCanTransform.localPosition = Vector3.zero;
        beerCanTransform.localRotation = Quaternion.identity;

        cameraTransform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, cameraTransform.eulerAngles.z);
    }
    private IEnumerator SmoothCameraRotation(float startXRotation, float endXRotation)
    {//From GPT
        float elapsedTime = 0f;

        while (elapsedTime < liftDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / liftDuration;


            float currentXRotation = Mathf.Lerp(startXRotation, endXRotation, t);
            cameraTransform.rotation = Quaternion.Euler(currentXRotation, cameraTransform.eulerAngles.y, cameraTransform.eulerAngles.z);

            yield return null;
        }

        cameraTransform.rotation = Quaternion.Euler(endXRotation, cameraTransform.eulerAngles.y, cameraTransform.eulerAngles.z);
    }
}


