using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel  : MonoBehaviour
{
    [SerializeField] private Transform buttonHolder;

    public virtual void Initialize()
    {
        //Debug.Log($"UIPanel:: \"{this.GetType().Name}\" is start initialize");

        for (int i = 0; i < transform.childCount; i++)
        {
            string childName = transform.GetChild(i).name;
            if (childName == "Buttons")
            {
                //Debug.Log($"UIPanel:: \"{this.GetType().Name}\" Find Button Holder");
                buttonHolder = transform.GetChild(i);
                break;
            }
        }
    }

    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);

    protected Button[] GetButtons()
    {
        if (buttonHolder != null)
        {
            return buttonHolder.GetComponentsInChildren<Button>();
        }
        
        return null;
    }
}