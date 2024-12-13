using UnityEngine;

public class BarrelPuzzle : MonoBehaviour
{
    public Light greenLight;
    public Light redLight;
    public Light activatedLight;
    public int[] code;
    int currentIndex;
    private bool isFinished;
    float redLightTimer = 0;
    public GameObject airWall1;
    public GameObject airWall2;

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
        if (code[currentIndex] == number)
        {
            if (++currentIndex == code.Length)
            {
                isFinished = true;
                greenLight.enabled = true;
                activatedLight.enabled = true;
                airWall1.SetActive(false);
                airWall2.SetActive(false);
            }
        }
        else
        {
            redLightTimer = 1f;
            currentIndex = 0;
        }
    }
}
