using UnityEngine;

public class KeypadButton : MonoBehaviour, IInteractable
{
    public int number;

    public void Interact() 
    {

        FindAnyObjectByType<KeypadPuzzle>().OnPress(number);
    }
}
