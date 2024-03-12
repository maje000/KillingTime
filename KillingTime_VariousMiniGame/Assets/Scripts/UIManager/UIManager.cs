using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager s_instance;

    [SerializeField] private UIPanel _startPanel;
    // Panels
    [SerializeField] private UIPanel[] _panels;
    [SerializeField] private UIPanel _currentPanel;
    [SerializeField] private readonly Stack<UIPanel> _history = new Stack<UIPanel>();

    // Popups
    [SerializeField] private UIPopup[] _popups;

    private void Awake() => s_instance = this;

    private void Start()
    {
        //Initialize();
    }

    public static void Initialize()
    {
        foreach (UIPanel uiPanel in s_instance._panels)
        {
            uiPanel.Initialize();
            uiPanel.Hide();
        }

        foreach (UIPopup uiPopup in s_instance._popups)
        {
            uiPopup.Initialize();
            uiPopup.Close();
        }
    }

    public static void Initialize(params UIPanel[] panels)
    {
        foreach(UIPanel panel in panels)
        {
            panel.Initialize();
            panel.Hide();
        }

        s_instance._panels = panels;
        s_instance._startPanel = panels[0];
    }

    public static void Initialize(params UIPopup[] popups)
    {
         foreach(UIPopup popup in popups)
        {
            popup.Initialize();
            popup.Close();
        }

        s_instance._popups = popups;
    }

    #region Panel
    public static T GetUIPanel<T>() where T : UIPanel
    {
        for (int i = 0; i < s_instance._panels.Length; i++)
        { 
            if (s_instance._panels[i] is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void ShowPanel<T>(bool remember = true) where T : UIPanel
    {
        for (int i = 0; i < s_instance._panels.Length; i++)
        {
            if (s_instance._panels[i] is T)
            {
                if (s_instance._currentPanel != null)
                {
                    if (remember)
                    {
                        s_instance._history.Push(s_instance._currentPanel);
                    }

                    s_instance._currentPanel.Hide();
                }

                s_instance._panels[i].Show();
                s_instance._currentPanel = s_instance._panels[i];
                return;
            }
        }

        Debug.Log($"\"{typeof(T).Name}\" 패널이 존재하지 않습니다.");
    }

    public static void ShowPanel(UIPanel view, bool rememeber = true)
    {
        if (s_instance._currentPanel != null)
        {
            if (rememeber)
            {
                s_instance._history.Push(s_instance._currentPanel);
            }

            s_instance._currentPanel.Hide();
        }

        view.Show();
        s_instance._currentPanel = view;
    }

    public static void ShowLastPanel()
    {
        if (s_instance._history.Count != 0)
        {
            ShowPanel(s_instance._history.Pop(), false);
        }
    }
    #endregion

    #region Popup
    public static void ShowPopup<T>() where T : UIPopup
    {
        foreach (UIPopup popup in s_instance._popups)
        {
            if (popup is T)
            {
                popup.Popup();
                break;
            }
        }
    }
    #endregion
}