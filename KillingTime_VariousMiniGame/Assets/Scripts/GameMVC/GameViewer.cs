using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 유저에게 인터페이스 제공
/// </summary>
public abstract class GameViewer : MonoBehaviour
{
    public abstract void Initialize();

    public static T GetViewer<T>() where T : GameViewer
    {
        T gameViewer = FindObjectOfType<T>();

        if (gameViewer != null)
        {
            return gameViewer;
        }
        else
        {
            GameObject newGameObject = new GameObject($"{typeof(T)}");
            return newGameObject.AddComponent<T>();
        }
    }

    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);
}