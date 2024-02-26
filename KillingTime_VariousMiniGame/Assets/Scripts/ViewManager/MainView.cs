using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View
{
    [SerializeField] private Button _startButton;

    public override void Initialize()
    {
        base.Initialize();

        _startButton.onClick.AddListener(() => ViewManager.Show<MiniGameListView>());
    }
}