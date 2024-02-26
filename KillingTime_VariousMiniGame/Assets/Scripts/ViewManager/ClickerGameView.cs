using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerGameView : View
{
    [SerializeField] private Button _backButton;

    public override void Initialize()
    {
        base.Initialize();

        _backButton.onClick.AddListener(() =>
        {
            GameManager.CloseGame();
            ViewManager.ShowLast();
        });
    }
}
