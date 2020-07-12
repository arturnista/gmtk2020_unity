using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFinalMenu : MonoBehaviour
{

    public static bool WON_GAME;

    void Start()
    {
        UIMessage.Main.OnCloseMessage += MainMenu;
        if (WON_GAME)
        {
            UIMessage.Main.Show("The anti-bomb squad defused the bomb!\nYour help was very much appreciated.");
        }
        else
        {
            UIMessage.Main.Show("The bomb exploded......................\nEvery body died.......\n\nAt least you tried?");
        }
    }

    void MainMenu()
    {
        UIMessage.Main.OnCloseMessage -= MainMenu;
        SceneManager.LoadScene("StartMenu");
    }

}
