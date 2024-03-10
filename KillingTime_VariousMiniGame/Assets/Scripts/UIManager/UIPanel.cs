using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPanel  : MonoBehaviour
{
    public virtual void Initialize() => Debug.Log($"UIPanel:: \"{this.GetType().Name}\" is start initialize");

    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);
}