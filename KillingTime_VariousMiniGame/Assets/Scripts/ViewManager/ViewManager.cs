using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ViewManager : MonoBehaviour
{
    private static ViewManager s_instance;

    [SerializeField] private View _startingView;
    [SerializeField] private View[] _views;
    [SerializeField] private View _currentView;
    [SerializeField] private readonly Stack<View> _history = new Stack<View>();

    private void Awake() => s_instance = this;
    private void Start()
    {
        for (int i = 0; i < _views.Length; i++)
        {
            _views[i].Initialize();
            _views[i].Hide();
        }

        // 최초 초기화
        if (_startingView != null)
        {
            Show(_startingView, false);
        }
        else
        {
            Show(_views[0], false);
        }
    }

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < s_instance._views.Length; i++)
        { 
            if (s_instance._views[i] is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < s_instance._views.Length; i++)
        {
            if (s_instance._views[i] is T)
            {
                if (s_instance._currentView != null)
                {
                    if (remember)
                    {
                        s_instance._history.Push(s_instance._currentView);
                    }

                    s_instance._currentView.Hide();
                }

                s_instance._views[i].Show();
                s_instance._currentView = s_instance._views[i];
                return;
            }
        }
    }

    public static void Show(View view, bool rememeber = true)
    {
        if (s_instance._currentView != null)
        {
            if (rememeber)
            {
                s_instance._history.Push(s_instance._currentView);
            }

            s_instance._currentView.Hide();
        }

        view.Show();
        s_instance._currentView = view;
    }

/// <summary>
/// 현재 창을 숨김. ShowLast()를 통해 다시 열기
/// </summary>
    public static void Hide()
    {
        if (s_instance._currentView != null)
        {
            s_instance._history.Push(s_instance._currentView);
            s_instance._currentView.Hide();

            s_instance._currentView = null;
        }
    }

    public static void ShowLast()
    {
        if (s_instance._history.Count != 0)
        {
            Show(s_instance._history.Pop(), false);
        }
    }
}