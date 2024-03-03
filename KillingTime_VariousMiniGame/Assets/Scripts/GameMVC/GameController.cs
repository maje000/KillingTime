using UnityEngine;

/// <summary>
/// Viewer와 Model을 연결해주며 로직 처리
/// </summary>
public abstract class GameController
{
    private GameViewer _gameViewer;
    protected GameViewer viewer { set => _gameViewer = value; }

    private GameModel _gameModel;
    protected GameModel model { set => _gameModel = value; }

    public abstract void Initialize();
}
