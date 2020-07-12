using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinalMenu : MonoBehaviour
{

    public static bool WON_GAME;

    void Start()
    {
        if (WON_GAME)
        {
            UIMessage.Main.Show("You defused the bomb!\nLets fucking go!");
        }
        else
        {
            UIMessage.Main.Show("The bomb exploded......................\nEvery body died.......\nyeah you dumb fuck");
        }
    }

}
