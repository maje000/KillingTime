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
    [SerializeField] private Image _screenCurtain;

    // Popups
    [SerializeField] private UIPopup[] _popups;

    private void Awake() => s_instance = this;

    private void Start()
    {
        Initialize();

        if (_startPanel != null)
        {
            _startPanel.Show();
        }
        else
        {
            _panels[0].Show();
        }

        FadeIn();
    }

    public void Initialize()
    {
        foreach (UIPanel uiPanel in _panels)
        {
            uiPanel.Initialize();
            uiPanel.Hide();
        }

        foreach (UIPopup uiPopup in _popups)
        {
            uiPopup.Initialize();
            uiPopup.Close();
        }
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


    #region Fade Effect
    Coroutine coFadeEffectHandle;
    /// <summary>
    /// 점점 흐려져서 화면을 덮음 안보임
    /// </summary>
    public static void FadeOut()
    {
        // 화면을 점점 덮는 연출 시작
        if (s_instance.coFadeEffectHandle != null)
        {
            s_instance.StopCoroutine(s_instance.coFadeEffectHandle);
            s_instance.coFadeEffectHandle = null;
        }

        s_instance.coFadeEffectHandle = s_instance.StartCoroutine(s_instance.CoFadeOut(Color.white));
    }

    /// <summary>
    /// 덮인 화면이 점점 나타남
    /// </summary>
    public static void FadeIn()
    {
        // 화면을 점점 여는 연출 시작
        if (s_instance.coFadeEffectHandle != null)
        {
            s_instance.StopCoroutine(s_instance.coFadeEffectHandle);
            s_instance.coFadeEffectHandle = null;
        }

        s_instance.coFadeEffectHandle = s_instance.StartCoroutine(s_instance.CoFadeIn(Color.white));
    }

    private IEnumerator CoFadeOut(Color fadeOutColor, float duration = 1f)
    {
        s_instance._screenCurtain.raycastTarget = true;

        _screenCurtain.color = fadeOutColor;
        Color currentColor = _screenCurtain.color;
        float currentTime = 0f;

        while(true)
        {
            currentColor = _screenCurtain.color;
            currentTime += Time.deltaTime;
            currentColor.a = currentTime/duration;

            if (currentColor.a > 1f)
            {
                currentColor.a = 1f;
                _screenCurtain.color = currentColor;
                break;
            }

            _screenCurtain.color = currentColor;

            yield return null;
        }

        yield return coFadeEffectHandle = null;
    }

    private IEnumerator CoFadeIn(Color fadeInColor, float duration = 1f)
    {
        fadeInColor.r = 1f;
        _screenCurtain.color = fadeInColor;
        Color currentColor = _screenCurtain.color;
        float currentTime = 0f;

        while(true)
        {
            currentColor = _screenCurtain.color;
            currentTime += Time.deltaTime;
            currentColor.a = 1f - currentTime/duration;

            if (currentColor.a <= 0f)
            {
                currentColor.a = 0f;
                _screenCurtain.color = currentColor;
                break;
            }

            _screenCurtain.color = currentColor;

            yield return null;
        }

        s_instance._screenCurtain.raycastTarget = false;
        yield return coFadeEffectHandle = null;
    }
    #endregion
}