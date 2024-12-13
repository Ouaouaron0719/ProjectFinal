using UnityEngine;

public class KeypadButton : MonoBehaviour, IInteractable
{
    //public int number;

    //public void Interact() 
    //{

    //    FindAnyObjectByType<KeypadPuzzle>().OnPress(number);
    //}
    public int number; 
    public MonoBehaviour targetPuzzle; 

    public void Interact()
    {
        if (targetPuzzle != null)
        {
            if (targetPuzzle is KeypadPuzzle keypadPuzzle)
            {
                keypadPuzzle.OnPress(number);
            }
            else if (targetPuzzle is BarrelPuzzle barrelPuzzle)
            {
                barrelPuzzle.OnPress(number);
            }
            else
            {
                Debug.LogWarning("Unsupported puzzle type: " + targetPuzzle.GetType());
            }
        }
        else
        {
            Debug.LogWarning("No target puzzle assigned to this keypad button.");
        }
    }
}
