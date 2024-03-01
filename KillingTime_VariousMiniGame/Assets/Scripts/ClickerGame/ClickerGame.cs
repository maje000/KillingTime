using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerGame : Game
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
        // 유저의 입력
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // 입력의 방식 - Raycast
        //    List<RaycastResult> results = new();
        //    PointerEventData pointerEventData = new PointerEventData(null);
        //    pointerEventData.position = Input.mousePosition;
        //    _graphicRaycaster.Raycast(pointerEventData, results);

        //    // 입력의 결과 - 충돌이 발생한 TouchPoint
        //    if (results.Count > 0)
        //    {
        //        GameObject result = results[0].gameObject;
        //        if (result.tag == "TouchPoint")
        //        {
        //            // 충돌의 결과 > 게임 로직
        //            _score++;
        //            int positionCount = _positions.Length;
        //            int randomIndex = Random.Range(0, positionCount);
        //            result.GetComponent<RectTransform>().anchoredPosition = _positions[randomIndex];
        //        }
        //    }
        //}
    }

    public Vector2 GetRandomPosition()
    {
        int positionCount = _positions.Length;
        int randomIndex = Random.Range(0, positionCount);

        return _positions[randomIndex];
    }
}