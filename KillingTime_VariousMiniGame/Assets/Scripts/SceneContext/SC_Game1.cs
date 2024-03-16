using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Game1 : SceneContext
{
    [SerializeField] private UIPanel[] panels;
    ClickerGameController controller = new ClickerGameController();

    public override void Initialize()
    {
        UIManager.Initialize(panels);
        controller.Initialize();
        SceneLoader.Instance.SetSceneClearEvent = ClearScene().GetEnumerator();
    }

    public override void StartScene()
    {
        UIManager.ShowPanel<Panel_Game1>();
        controller.Start();
    }

    public override IEnumerable ClearScene() 
    {
        Debug.Log("On SC_Game1 ClearScene");
        controller.Clear();
        yield return null;
    }
}
