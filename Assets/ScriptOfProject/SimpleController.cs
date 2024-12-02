using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SimpleController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2.5f;
    public float crouchHeight = 0.5f;
    private float originalHeight;
    private bool isCrouching = false;

    [Header("Camera Settings")]
    public Camera playerCamera;
    public float mouseSensitivity = 2f;
    public float maxLookAngle = 60f;

    [Header("HeadBob Settings")]
    public bool enableHeadBob = true;
    public float bobSpeed = 10f;
    public Vector3 bobAmount = new Vector3(0.1f, 0.05f, 0);

    [Header("Interaction Settings")]
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;

    [Header("Flashlight Settings")]
    public GameObject leftEyeLight;
    public GameObject rightEyeLight;
    private bool flashlightEnabled = false;
    private bool flashlightUnlocked = false;

    private Rigidbody rb;
    private float yaw = 0f;
    private float pitch = 0f;
    private Vector3 originalCameraPosition;
    private bool isSprinting = false;
    private bool isWalking = false;
    private float timer = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (playerCamera != null)
        {
            originalCameraPosition = playerCamera.transform.localPosition;
        }

        originalHeight = transform.localScale.y;

        Cursor.lockState = CursorLockMode.Locked;

        // Disable flashlights at the start
        if (leftEyeLight != null) leftEyeLight.SetActive(false);
        if (rightEyeLight != null) rightEyeLight.SetActive(false);
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovementInput();
        HandleInteraction();
        HandleFlashlightToggle();

        if (enableHeadBob)
        {
            HandleHeadBob();
        }
    }

    private void HandleMouseLook()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        if (playerCamera != null)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }
    }

    private void HandleMovementInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveHorizontal, 0, moveVertical).normalized);

        // Sprint
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? sprintSpeed : (isCrouching ? crouchSpeed : walkSpeed);

        rb.linearVelocity = new Vector3(moveDirection.x * currentSpeed, rb.linearVelocity.y, moveDirection.z * currentSpeed);

        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
            transform.localScale = new Vector3(transform.localScale.x, isCrouching ? crouchHeight : originalHeight, transform.localScale.z);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();

                    // Unlock flashlight if interacting with the correct object
                    if (hit.collider.CompareTag("FlashlightUnlock"))
                    {
                        flashlightUnlocked = true;
                        Debug.Log("Flashlight unlocked!" + flashlightUnlocked);
                    }
                }
                else
                {
                    Debug.Log($"Hit {hit.collider.name}, but it is not interactable.");
                }
            }
            else
            {
                Debug.Log("No object hit.");
            }
        }
    }

    private void HandleFlashlightToggle()
    {
        if (flashlightUnlocked && Input.GetKeyDown(KeyCode.Q))
        {
            flashlightEnabled = !flashlightEnabled;
            if (leftEyeLight != null) leftEyeLight.SetActive(flashlightEnabled);
            if (rightEyeLight != null) rightEyeLight.SetActive(flashlightEnabled);

            Debug.Log(flashlightEnabled ? "Flashlight turned on." : "Flashlight turned off.");
        }
    }

    private void HandleHeadBob()
    {
        if (isWalking || isSprinting)
        {
            timer += Time.deltaTime * (isSprinting ? bobSpeed * 1.5f : bobSpeed);
            playerCamera.transform.localPosition = originalCameraPosition + new Vector3(Mathf.Sin(timer) * bobAmount.x, Mathf.Cos(timer * 2) * bobAmount.y, 0);
        }
        else
        {
            timer = 0;
            playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, originalCameraPosition, Time.deltaTime * bobSpeed);
        }
    }
}
