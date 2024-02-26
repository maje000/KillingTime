using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameListView : View
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _goGame1Button;

    public override void Initialize()
    {
        base.Initialize();

        _backButton.onClick.AddListener(() => ViewManager.ShowLast());
        _goGame1Button.onClick.AddListener(() =>
        {
            ViewManager.Show<ClickerGameView>();
            GameManager.PlayGame<ClickerGame>();
        });
    }
}
