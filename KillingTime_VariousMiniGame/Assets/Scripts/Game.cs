using UnityEngine;
using UnityEngine.Events;

public interface iGame
{
    // todo:: 인터페이스 구성하기
}

public abstract class Game : MonoBehaviour, iGame
{
    /// <summary>
    /// 게임 중인지
    /// </summary>
    protected bool _isPlay;

    public UnityEvent _onGameOverEvent;

    /// <summary>
    /// 게임 최초 초기화. 
    /// todo::비동기 작업이 있을 경우(리소스 로딩 등), 비동기 처리가 필요함.
    /// </summary>
    public virtual void Initialize() => Debug.Log($"Game:: \"{this.GetType().Name}\" is start initialize");
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        _isPlay = false;
        gameObject.SetActive(false);
    }

    public virtual void Play() => _isPlay = true;

    /// <summary>
    /// 게임 메카닉스
    /// </summary>
    protected abstract void Running();

    /// <summary>
    /// 게임 종료 트리거
    /// </summary>
    /// <returns></returns>
    protected abstract bool IsOver();

    /// <summary>
    /// 게임 종료를 위한 정리. 다음에 바로 시작이 가능한 상태로 정리를 해놓아야 함.
    /// </summary>
    public abstract void OnFinishedGame();

    // Update is called once per frame
    void Update()
    {
        if (_isPlay)
        {
            if (IsOver())
            {
                _onGameOverEvent?.Invoke();
                _isPlay = false;
            }

            Running();
        }
    }
}