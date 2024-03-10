using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultView : UIPanel
{
    [SerializeField] private Button closeButton;

    public override void Initialize()
    {
        base.Initialize();

        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    private void OnClickCloseButton()
    {
        UIManager.ShowLast();
    }
}
