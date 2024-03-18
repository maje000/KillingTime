using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerGameViewer : GameViewer
{
    private GraphicRaycaster graphicRaycaster;

    public override void Initialize()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
        if (graphicRaycaster == null)
        {
            graphicRaycaster = gameObject.AddComponent<GraphicRaycaster>();
        }
    }

    public void Update()
    {
        if (tic != null)
        {
            tic();
        }

        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
