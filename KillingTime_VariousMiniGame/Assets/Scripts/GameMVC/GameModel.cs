using UnityEngine;


/// <summary>
/// 게임의 정보를 갖고 있는다
/// </summary>
public abstract class GameModel
{
    /// <summary>
    /// 게임 최초 초기화. 
    /// todo::비동기 작업이 있을 경우(리소스 로딩 등), 비동기 처리가 필요함.
    /// </summary>
    public virtual void Initialize() => Debug.Log($"Game:: \"{this.GetType().Name}\" is start initialize");
}