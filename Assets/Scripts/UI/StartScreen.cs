using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction PlayButtonClicked;

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
