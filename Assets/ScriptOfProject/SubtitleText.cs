using System;
using System.Net.Http;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleText : MonoBehaviour
{
    public Image fadeBackground;
    public TMP_Text message;
    private float messageTimer;

    internal void ShowText(string text) 
    {
        ShowText(text, text.Length * 0.1f);
    }
    internal void ShowText(string text, float duration)
    {
        message.text = text;
        fadeBackground.enabled = true;
        messageTimer = duration;
    }

    private void Update()
    {
        if (messageTimer > 0) 
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                Clear();
            }
        }
    }

    private void Clear()
    {
        fadeBackground.enabled = false;
        message.text = " ";
    }

    private void Start()
    {
        Clear();
    }
}
