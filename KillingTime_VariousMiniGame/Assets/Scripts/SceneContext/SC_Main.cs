using System.Collections;
using UnityEngine;

public class SC_Main : SceneContext
{
    [SerializeField] private UIPanel[] panels;
    [SerializeField] private UIPopup[] popups;

    public override void Initialize()
    {
        UIManager.Initialize(panels);
        UIManager.Initialize(popups);
    }

    public override void StartScene()
    {
        UIManager.ShowPanel<Panel_Main>();
    }

    public override IEnumerator ClearScene()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 씬 시작 함수. 추후 SceneStart()로 바꾸기
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //UIManager.ShowPanel<Panel_Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
