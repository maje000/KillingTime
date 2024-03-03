using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerGame : GameModel
{
    [SerializeField] private int _score;
    [SerializeField] private float _currentTimeToFlow;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    Vector2[] _positions = new Vector2[] {
        new Vector3(-330f, -330*2f),
        new Vector3(-330f, -330*1f),
        new Vector3(-330f, 330*0f),
        new Vector3(-330f, 330*1f),
        new Vector3(-330f, 330*2f),
        new Vector3(0f, -330*2f),
        new Vector3(0f, -330*1f),
        new Vector3(0f, -330*0f),
        new Vector3(0f, -330*1f),
        new Vector3(0f, -330*2f),
        new Vector3(330f, -330*2f),
        new Vector3(330f, -330*1f),
        new Vector3(330f, -330*0f),
        new Vector3(330f, -330*1f),
        new Vector3(330f, -330*2f),
    };

    public override void Initialize()
    {
        Debug.Log($"{this.GetType().Name} is On Initialize");
        _currentTimeToFlow = 0f;

        base.Initialize();
    }

    public Vector2 GetRandomPosition()
    {
        int positionCount = _positions.Length;
        int randomIndex = Random.Range(0, positionCount);

        return _positions[randomIndex];
    }
}