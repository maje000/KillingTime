using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_GameResult : UIPopup
{
    [SerializeField] private Button closeButton;

    public override void Initialize()
    {
        Button[] buttons = GetButtons();

        foreach(Button button in buttons)
        {
            if (button.name == "Close")
            {
                UIManager.ShowLastPanel();
            }
        }
    }

    public override void Popup()
    {
        throw new System.NotImplementedException();
    }

    public override void Close()
    {
        throw new System.NotImplementedException();
    }

    private void OnClickCloseButton()
    {
        UIManager.ShowLastPanel();
    }
}
