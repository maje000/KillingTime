using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UIPanel
{
    [SerializeField] private Button _startButton;

    public override void Initialize()
    {
        base.Initialize();

        _startButton.onClick.AddListener(() => UIManager.Show<MiniGameListView>());
    }
}
