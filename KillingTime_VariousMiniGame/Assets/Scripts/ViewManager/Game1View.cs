using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1View : View
{
    [SerializeField] private Button _backButton;

    public override void Initialize()
    {
        base.Initialize();

        _backButton.onClick.AddListener(() => ViewManager.ShowLast());
    }
}
