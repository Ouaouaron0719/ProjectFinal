using System.Net.Http;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleText : MonoBehaviour
{
    public Image fadeBackground;
    public TMP_Text message;

    private void Start()
    {
        fadeBackground.enabled = false;
        message.text = " ";
    }
}
