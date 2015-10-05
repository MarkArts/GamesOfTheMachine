using UnityEngine;
using System.Collections;
using System;

public class LevelButton : Button
{
    public string level;
    public bool checkLevel;
    private bool active;

    public override void myStart()
    {
        active = (checkLevel) ? PlayerPrefs.GetInt(level, 0) > 0 : true;

        if (!active)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    public override void onButtonPress()
    {
        if (active) {
            Application.LoadLevel(level);
        }
    }
}
