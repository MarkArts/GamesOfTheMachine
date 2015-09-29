using UnityEngine;
using System.Collections;
using System;

public class QuitButton : Button {

    public override void onButtonPress()
    {
        Application.Quit();
    }
}
