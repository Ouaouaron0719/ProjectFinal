using System;
using UnityEngine;

public class KeypadPuzzle : MonoBehaviour
{
    public Light greenLight;    
    public Light redLight;
    public Light activatedLight;
    public int[] code;
    public Animator doorAnimator; 
    int currentIndex;
    private bool isFinished;
    float redLightTimer = 0;

    private void Update()
    {
        if (redLightTimer > 0)
        {
            if (!redLight.enabled) 
            {
                redLight.enabled = true;
            }
            redLightTimer -= Time.deltaTime;
        }
        else
        {
            if (redLight.enabled) 
            {
                redLight.enabled = false;
            }
        }
    }
    internal void OnPress(int number)
    {
        if (isFinished) return; 
        if(code[currentIndex] == number) 
        {
            if(++currentIndex == code.Length) 
            {
                isFinished = true;
                greenLight.enabled = true;
                activatedLight.enabled = true;
                Invoke(nameof(PlayDoorAnimation),2f);
            }
        }
        else 
        {
            redLightTimer = 1f;
            currentIndex = 0;
        }
    }
    private void PlayDoorAnimation()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
    }
}
