using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerGameController : GameController
{
    public override void Initialize()
    {
        ClickerGameViewer clickerGameViewer = GameObject.FindObjectOfType<ClickerGameViewer>();
        viewer = clickerGameViewer;

        ClickerGame gameModel = new ClickerGame();
        model = gameModel;
    }
}
