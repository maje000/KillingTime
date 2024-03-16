using System.Collections;
using System.Collections.Generic;
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
        model = new ClickerGame();
    }

    public override void Start()
    {

    }
}
