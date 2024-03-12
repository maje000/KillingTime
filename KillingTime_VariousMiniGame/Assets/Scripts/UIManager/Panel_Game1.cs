using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Game1 : UIPanel
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
                button.onClick.AddListener(() => SceneLoader.Instance.LoadScene("MainScene"));
            }
        }
    }
}
