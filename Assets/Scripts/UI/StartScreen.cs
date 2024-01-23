using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : Window
{
    public event Action StartButtonClicked;

    public override void OnButtonClick()
    {
        StartButtonClicked?.Invoke();
    }
}
