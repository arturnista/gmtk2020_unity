using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFlashDisplay : MonoBehaviour
{
    
    private static UIFlashDisplay s_Instance;
    public static UIFlashDisplay Instance { get => s_Instance; }

    private Image _image;

    void Awake()
    {
        s_Instance = this;
        _image = GetComponent<Image>();
    }

    public void Flash(Color color)
    {
        StopAllCoroutines();
        StartCoroutine(FlashCoroutine(color));
    }

    IEnumerator FlashCoroutine(Color color)
    {
        float alpha = color.a;
        _image.color = color;
        while (alpha > 0f)
        {
            alpha -= 3f * Time.deltaTime;
            color.a = alpha;
            _image.color = color;
            yield return null;
        }
    }
}
