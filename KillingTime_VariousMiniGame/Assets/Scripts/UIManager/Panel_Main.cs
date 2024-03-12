using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Main : UIPanel
{
    public override void Initialize()
    {
        base.Initialize();

        Button[] buttons = GetButtons();

        int buttonCount = buttons.Length;

        foreach(Button button in buttons)
        {
            string buttonName = button.name;
            if (buttonName == "Start")
            {
                button.onClick.AddListener(() => UIManager.ShowPanel<Panel_GameList>());
            }
            else if (buttonName == "Exit")
            {
                // 종료 알림 판 띄우기
                button.onClick.AddListener(UIManager.ShowPopup<Popup_GameExit>);
            }
        }
    }
}
