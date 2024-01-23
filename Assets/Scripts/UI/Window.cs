using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Window : MonoBehaviour
{
    protected CanvasGroup _canvasGroup;

    protected void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    public abstract void OnButtonClick();
}
