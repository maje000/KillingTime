using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Game1 : SceneContext
{
    [SerializeField] private UIPanel[] panels;
    GameController controller;

    public override void Initialize()
    {
        UIManager.Initialize(panels);
        controller.Initialize();
    }

    public override void SceneStart()
    {
        UIManager.ShowPanel<Panel_Game1>();
    }
}
