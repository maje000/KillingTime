using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerGameViewer : GameViewer
{
    public enum GameState
    { 
        None,
        Play,
        GameOver,
        GameClear
    }

    [SerializeField] private Canvas canvas;
    private GraphicRaycaster graphicRaycaster;

    private Transform touchPoint;
    public UnityAction onTouchPointClick;
    private Button startButton;
    public UnityAction onStartButtonClick
    {
        set
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                value.Invoke();
                startButton.gameObject.SetActive(false);
            });
        }
    }
    private TMPro.TextMeshProUGUI countdownText;
    public int countdown 
    { 
        set
        {
            if (value == -1)
            {
                countdownText.gameObject.SetActive(false);
            }
            else
            {
                if (countdownText.gameObject.activeSelf == false)
                {
                    countdownText.gameObject.SetActive(true);
                }
                countdownText.text = value.ToString();
            }
        }
    }
    private TMPro.TextMeshProUGUI scoreText;
    private const string SCORE_TEXT = "score: {0}";
    public int score
    {
        set => scoreText.text = string.Format(SCORE_TEXT, value);
    }
    private Transform _resultBoard;
    private TMPro.TextMeshProUGUI _resultBoard_socreText;
    public int resultBoard_score
    {
        set
        {
            _resultBoard_socreText.text = string.Format(SCORE_TEXT, value);
        }
    }
    private Button _resultBoard_exitButton;
    public UnityAction onExitButtonClickInResultBoard
    {
        set
        {
            _resultBoard_exitButton.onClick.RemoveAllListeners();
            _resultBoard_exitButton.onClick.AddListener(() =>
            {
                value.Invoke();
            });
        }
    }
    private Button _resultBoard_restartButton;
    public UnityAction onRestartButtonClickInResultBoard
    {
        set
        {
            _resultBoard_restartButton.onClick.RemoveAllListeners();
            _resultBoard_restartButton.onClick.AddListener(() =>
            {
                value.Invoke();
            });
        }
    }

    List<RaycastResult> touchResults;
    GameState currentGameState;
    public GameState gameState { 
        get => currentGameState; 
        set
        {
            GameState state = value;
            if (state == GameState.None)
            {
                startButton.gameObject.SetActive(true);

                touchPoint.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(false);
                _resultBoard.gameObject.SetActive(false);
            }
            else if (state == GameState.Play)
            {
                touchPoint.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(true);
                
                _resultBoard.gameObject.SetActive(false);
            }
            else if (state == GameState.GameOver)
            {
                _resultBoard.gameObject.SetActive(true);
            }
            else if (state == GameState.GameClear)
            {

            }

            currentGameState = state;
        }
    }

    public override void Initialize()
    {
        graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
        touchResults = new List<RaycastResult>();
        currentGameState = GameState.None;

        // canvas 속 UI 찾기
        int canvasChildCount = canvas.transform.childCount;
        for (int i = 0; i < canvasChildCount; i++)
        {
            Transform child = canvas.transform.GetChild(i);
            if (child.name == "TouchPoint")
            {
                touchPoint = child;
            }
            else if (child.name == "StartButton")
            {
                startButton = child.GetComponent<Button>();
            }
            else if (child.name == "CountdownText")
            {
                countdownText = child.GetComponent<TMPro.TextMeshProUGUI>();
            }
            else if (child.name == "ScoreText")
            {
                scoreText = child.GetComponent<TMPro.TextMeshProUGUI>();
            }
            else if (child.name == "ResultBoard")
            {
                _resultBoard = child;
                ClickerGame_ResultBoard resultBoard = _resultBoard.GetComponent<ClickerGame_ResultBoard>();
                _resultBoard_socreText = resultBoard.scoreText;
                _resultBoard_exitButton = resultBoard.exitButton;
                _resultBoard_restartButton = resultBoard.restartButton;
            }
        }

        touchPoint.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        _resultBoard.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (tic != null)
        {
            tic();
        }

        if (currentGameState == GameState.Play)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerEventData = new PointerEventData(null);
                pointerEventData.position = Input.mousePosition;

                graphicRaycaster.Raycast(pointerEventData, touchResults);

                foreach (RaycastResult result in touchResults)
                {
                    if (ReferenceEquals(result.gameObject.transform, touchPoint))
                    {
                        onTouchPointClick?.Invoke();
                    }
                }

                touchResults.Clear();
            }
        }
    }

    
}
