using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxOpen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _hotkeyText;
    private bool working;

    void Update()
    {
        if(tag != "ItemBox")
        {
            _hotkeyText.text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player" && tag == "ItemBox")
        {
            _hotkeyText.text = "F";
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            _hotkeyText.text = "";
        }
    }
}
