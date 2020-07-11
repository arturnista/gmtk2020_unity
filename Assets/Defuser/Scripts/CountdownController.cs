using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI textTimer;
    [SerializeField] 
    private float time;
    
    private void Update()
    {
        time -= Time.deltaTime;
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if(textTimer != null)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.RoundToInt(time % 60f);

            string formatedSeconds = seconds.ToString();

            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }

            textTimer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        if(time <= 0)
        {
            textTimer.text = "00:00";
        }
    }
}
