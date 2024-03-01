using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo:: Controller Manager가 필요하려나...? ㅠㅠ
public class ClickerGameController : MonoBehaviour
{
    ClickerGameView _gameView;
    ClickerGame _gameModel;

    private void Start()
    {
        _gameView = GetComponent<ClickerGameView>();
        _gameModel = GetComponent<ClickerGame>();

        Initialize();
    }

    public void Initialize()
    {
        _gameView.onGraphicRaycastHit.AddListener(OnGraphicRaycastHit);
        _gameView.onBackButtonClick.AddListener(OnBackButtonClick);
    }

    private void OnGraphicRaycastHit(GameObject hit)
    {
        _gameModel.GetRandomPosition();
    }

    private void OnBackButtonClick()
    {
        GameManager.CloseGame();
        ViewManager.ShowLast();
    }
}
