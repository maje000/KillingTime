using UnityEditor;
using UnityEngine.UI;

public class Popup_GameExit : UIPopup
{
    public override void Initialize()
    {
        Button[] buttons = GetButtons();

        foreach(Button button in buttons)
        {
            string buttonName = button.name;

            if (buttonName == "Yes")
            {
                #if UNITY_EDITOR
                button.onClick.AddListener(() => EditorApplication.isPlaying = false);
                #else
                // 어플 종료
                #endif
            }
            else if (buttonName == "Cancel")
            {
                button.onClick.AddListener(Close);
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
}
