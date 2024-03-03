using UnityEngine;

/// <summary>
/// Viewer�� Model�� �������ָ� ���� ó��
/// </summary>
public abstract class GameController
{
    private GameViewer _gameViewer;
    protected GameViewer viewer { set => _gameViewer = value; }

    private GameModel _gameModel;
    protected GameModel model { set => _gameModel = value; }

    public abstract void Initialize();
}
