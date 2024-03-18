using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Transform touchPoint;
    public UnityAction onTouchPointClick;
    [SerializeField] private Button startButton;
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
    [SerializeField] private TMPro.TextMeshProUGUI countdownText;
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

    List<RaycastResult> touchResults;
    GameState currentGameState;
    public GameState gameState { get => currentGameState; }

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
        }

        touchPoint.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(false);
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
                        // 이벤트 발생
                        onTouchPointClick?.Invoke();
                    }
                }

                touchResults.Clear();
            }
        }
    }

    public void GameStart()
    {
        currentGameState = GameState.Play;
        touchPoint.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        currentGameState = GameState.GameOver;
    }
}
