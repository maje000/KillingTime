using UnityEngine;

public class SC_Game2 : SceneContext
{
    [SerializeField] private UIPanel[] panels;

    public override void Initialize()
    {
        if (panels != null)
        {
            UIManager.Initialize(panels);    
        }
    }

    public override void StartScene()
    {
        UIManager.ShowPanel<Panel_Game2>();
    }
}
