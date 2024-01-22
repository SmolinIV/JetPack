using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
