using UnityEngine;
using System.Collections;
using System;

public class LevelButton : Button
{
    public string level;

    public override void onButtonPress()
    {
        Application.LoadLevel(level);
    }
}
