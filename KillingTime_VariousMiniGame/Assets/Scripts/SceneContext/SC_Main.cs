using UnityEngine;

public class SC_Main : SceneContext
{
    public override void Initialize()
    {
        
    }

    public override void SceneStart()
    {

    }

    /// <summary>
    /// 씬 시작 함수. 추후 SceneStart()로 바꾸기
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        UIManager.ShowPanel<Panel_Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
