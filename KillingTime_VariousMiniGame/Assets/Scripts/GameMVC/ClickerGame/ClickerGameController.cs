using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class ClickerGameController : GameController
{
    ClickerGameViewer clickerGameViewer;
    ClickerGame clickerGame;

    float flowTime;
    WaitForSeconds waitOneSecond;

    /// <summary>
    /// 데이터 초기화 + 초기 화면 구성
    /// Viewer는 미리 생성이 필요함...
    /// </summary>
    public override void Initialize()
    {
        clickerGame = new ClickerGame();
        clickerGame.Initialize();

        clickerGameViewer = GameViewer.GetViewer<ClickerGameViewer>();
        clickerGameViewer.Initialize();
        clickerGameViewer.tic += Tic;
        clickerGameViewer.onStartButtonClick = Start;
        clickerGameViewer.onTouchPointClick = OnTouchPointClick;
        clickerGameViewer.onExitButtonClickInResultBoard = ExitGame;
        clickerGameViewer.onRestartButtonClickInResultBoard = GameRestart;

        flowTime = 0f;
        waitOneSecond = new WaitForSeconds(1f);
    }

    public override void Start()
    {
        // 게임 StartButton을 주고
        // 버튼을 누르면 3, 2, 1 카운트를 하고 게임 시작
        clickerGameViewer.StartCoroutine(coGameStart());
    }

     public override void Clear()
    {
        
    }

    private void Tic()
    {
        if (clickerGameViewer.gameState == ClickerGameViewer.GameState.Play)
        {
            flowTime += Time.deltaTime;

            if (flowTime > 30f)
            {
                flowTime = 0;
                clickerGameViewer.resultBoard_score = clickerGame.score;
                clickerGameViewer.gameState = ClickerGameViewer.GameState.GameOver;
            }
        }
    }

    private IEnumerator coGameStart()
    {
        yield return null;
        int countdown = 4;

        while(true)
        {
            countdown--;
            clickerGameViewer.countdown = countdown;

            if (countdown == -1) break;

            yield return waitOneSecond;
        }

        clickerGameViewer.gameState = ClickerGameViewer.GameState.Play;
    }

    private void OnTouchPointClick()
    {
        Debug.Log("touchtouch");
        clickerGame.touchPoint.anchoredPosition = clickerGame.GetRandomPosition();
        clickerGame.score++;

        clickerGameViewer.score = clickerGame.score;
    }

    private void ExitGame()
    {
        SceneLoader.Instance.LoadScene("MainScene");
    }

    private void GameRestart()
    {
        clickerGame.score = 0;
        clickerGameViewer.score = 0;
        clickerGameViewer.gameState = ClickerGameViewer.GameState.None;
    }
}