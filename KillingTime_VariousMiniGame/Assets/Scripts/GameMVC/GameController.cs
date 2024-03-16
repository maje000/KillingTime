using UnityEngine;

/// <summary>
/// Viewer�� Model�� �������ָ� ���� ó��
/// </summary>
public abstract class GameController
{
    protected GameViewer viewer { get; set; }

    protected GameModel model { get; set; }

    public abstract void Initialize();
    public abstract void Start();
    public abstract void Clear();
}
