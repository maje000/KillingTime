using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_GameResult : UIPopup
{
    public override void Initialize()
    {
        Button[] buttons = GetButtons();

        foreach(Button button in buttons)
        {
            if (button.name == "Close")
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(OnClickCloseButton);
            }
        }
    }

    public override void Popup()
    {
        this.gameObject.SetActive(true);
    }

    public override void Close()
    {
        this.gameObject.SetActive(false);
    }

    private void OnClickCloseButton()
    {
        SceneLoader.Instance.LoadScene("MainScene");
    }
}
