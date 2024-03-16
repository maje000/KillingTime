using System.Collections;
using UnityEngine;

public class SC_Intro : SceneContext
{
    Coroutine coSceneInit;

    public override void Initialize()
    {

    }

    public override void StartScene()
    {
        
    }

    private void Start()
    {
        coSceneInit = StartCoroutine(CoSceneInit());
    }

    private IEnumerator CoSceneInit()
    {
        yield return null;

        yield return new WaitForSeconds(5f);

        if (coSceneInit != null)
        {
            StopCoroutine(coSceneInit);
            coSceneInit = null;
        }
        
        SceneLoader.Instance.LoadScene("MainScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coSceneInit != null)
            {
                StopCoroutine(coSceneInit);
                coSceneInit = null;
            }

            SceneLoader.Instance.LoadScene("MainScene");
        }
    }

    public override IEnumerable ClearScene()
    {
        throw new System.NotImplementedException();
    }
}
