using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPopup : MonoBehaviour
{
    [SerializeField] private Transform buttonHolder;

    public abstract void Initialize();
    public abstract void Popup();
    public abstract void Close();

    protected Button[] GetButtons()
    {
        if (buttonHolder != null)
        {
            return buttonHolder.GetComponentsInChildren<Button>();
        }

        return null;
    }
}
