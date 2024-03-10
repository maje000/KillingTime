using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager s_instance;

    [SerializeField] private UIPanel _startPanel;
    [SerializeField] private UIPanel[] _views;
    [SerializeField] private UIPanel _currentView;
    [SerializeField] private readonly Stack<UIPanel> _history = new Stack<UIPanel>();
    [SerializeField] private Image _screenCurtain;

    private void Awake() => s_instance = this;
    private void Start()
    {
        for (int i = 0; i < _views.Length; i++)
        {
            _views[i].Initialize();
            _views[i].Hide();
        }

        // 최초 초기화
        if (_startPanel != null)
        {
            Show(_startPanel, false);
        }
        else
        {
            Show(_views[0], false);
        }
    }

    public static T GetUIPanel<T>() where T : UIPanel
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

    public static void Show<T>(bool remember = true) where T : UIPanel
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

    public static void Show(UIPanel view, bool rememeber = true)
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

    public static void ShowLast()
    {
        if (s_instance._history.Count != 0)
        {
            Show(s_instance._history.Pop(), false);
        }
    }

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
        _screenCurtain.color = fadeOutColor;
        Color currentColor = _screenCurtain.color;
        float currentTime = 0f;

        while(true)
        {
            currentColor = _screenCurtain.color;
            currentTime += Time.deltaTime;
            currentColor.r = currentTime/duration;

            if (currentColor.r < 0)
            {
                currentColor.r = 0f;
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
            currentColor.r = 1f - currentTime/duration;

            if (currentColor.r >= 1)
            {
                currentColor.r = 1f;
                _screenCurtain.color = currentColor;
                break;
            }

            _screenCurtain.color = currentColor;

            yield return null;
        }

        yield return coFadeEffectHandle = null;
    }
}