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
        // ������ �Է�
        if (Input.GetMouseButtonDown(0))
        {
            // �Է��� ��� - Raycast
            List<RaycastResult> results = new();
            PointerEventData pointerEventData = new PointerEventData(null);
            pointerEventData.position = Input.mousePosition;
            _graphicRaycaster.Raycast(pointerEventData, results);

            // �Է��� ��� - �浹�� �߻��� TouchPoint
            if (results.Count > 0)
            {
                // �浹ü �������ֱ�
                GameObject result = results[0].gameObject;
                onGraphicRaycastHit?.Invoke(result);
            }
        }
    }
}
