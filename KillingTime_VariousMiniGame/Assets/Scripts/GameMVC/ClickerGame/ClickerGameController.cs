using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ClickerGameController : GameController
{
    /// <summary>
    /// 데이터 초기화 + 초기 화면 구성
    /// Viewer는 미리 생성이 필요함...
    /// </summary>
    public override void Initialize()
    {
        viewer = GameViewer.GetViewer<ClickerGameViewer>();
        viewer.Initialize();
        viewer.tic = Tic;

        model = new ClickerGame();
        model.Initialize();
    }

    public override void Start()
    {

    }

     public override void Clear()
    {
        
    }

    private void Tic()
    {
        Debug.Log(Time.deltaTime);
    }
}
