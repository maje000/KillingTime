using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameListView : UIPanel
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _goGame1Button;

    public override void Initialize()
    {
        base.Initialize();

        _backButton.onClick.AddListener(() => UIManager.ShowLast());
        _goGame1Button.onClick.AddListener(() => { });
    }
}
