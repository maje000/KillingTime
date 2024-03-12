using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntroSceneContext : MonoBehaviour
{
    Coroutine coSceneInit;

    public void Initialize()
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
}
