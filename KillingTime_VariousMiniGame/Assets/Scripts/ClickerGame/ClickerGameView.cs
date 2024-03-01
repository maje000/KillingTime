using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerGameView : View
{
    private Transform _touchPoint;

    [SerializeField] private Button _backButton;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;

    public UnityEvent<GameObject> onGraphicRaycastHit;
    public UnityEvent onBackButtonClick;

    public override void Initialize()
    {
        base.Initialize();

        _backButton.onClick.AddListener(onBackButtonClick.Invoke);
    }

    private void Update()
    {
        // 유저의 입력
        if (Input.GetMouseButtonDown(0))
        {
            // 입력의 방식 - Raycast
            List<RaycastResult> results = new();
            PointerEventData pointerEventData = new PointerEventData(null);
            pointerEventData.position = Input.mousePosition;
            _graphicRaycaster.Raycast(pointerEventData, results);

            // 입력의 결과 - 충돌이 발생한 TouchPoint
            if (results.Count > 0)
            {
                // 충돌체 전달해주기
                GameObject result = results[0].gameObject;
                onGraphicRaycastHit?.Invoke(result);
            }
        }
    }
}
