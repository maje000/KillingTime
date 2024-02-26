using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickerGame : Game
{
    [SerializeField] private int _score;
    [SerializeField] private float _currentTimeToFlow;
    UnityEvent onFinishedGame;

    public override void Initialize()
    {
        Debug.Log($"{this.GetType().Name} is On Initialize");
        _currentTimeToFlow = 0f;

        base.Initialize();
    }

    public override void OnFinishedGame()
    {
        _score = 0;
        _currentTimeToFlow = 0f;
    }

    protected override bool IsOver()
    {
        _currentTimeToFlow += Time.deltaTime;
        if (_currentTimeToFlow > 30f)
        {
            // 시간이 흘렀을 경우 게임 종료
            return true;
        }

        return false;
    }

    protected override void Running()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _score++;
        }
    }
}