using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_GameList : UIPanel
{
    public override void Initialize()
    {
        base.Initialize();

        Button[] buttons = GetButtons();

        foreach (Button button in buttons)
        {
            string buttonName = button.name;
            if (buttonName == "Back")
            {
                button.onClick.AddListener(() => UIManager.ShowLastPanel());
            }
            else if (buttonName == "Game1")
            {
                button.onClick.AddListener(() => {});
            }
        }
    }
}
