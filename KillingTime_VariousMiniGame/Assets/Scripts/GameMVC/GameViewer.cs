using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유저에게 인터페이스 제공
/// </summary>
public abstract class GameViewer : MonoBehaviour
{
    public abstract void Initialize();
    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);
}