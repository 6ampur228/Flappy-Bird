using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClicked;

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
