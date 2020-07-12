﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    
    [SerializeField]
    private Button _startGameButton;

    void Awake()
    {
        _startGameButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
    }

}
