using UnityEngine;
using System.Collections;
using System;

public class MuteButton : Button {

    public Sprite on;
    public Sprite of;

    private SpriteRenderer m_renderer;

    // Use this for initialization
    public override void myStart () {
        m_renderer = GetComponent<SpriteRenderer>();

        if (!PlayerPrefs.HasKey("mute"))
        {
            PlayerPrefs.SetInt("mute", 0);
        }
    }

    // Update is called once per frame
    public override void fuckdate () {

        if (PlayerPrefs.GetInt("mute") == 1)
        {
            m_renderer.sprite = of;
        }
        else
        {
            m_renderer.sprite = on;
        }
	}


    public override void onButtonPress()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            PlayerPrefs.SetInt("mute", 0);
        }
        else
        {
            PlayerPrefs.SetInt("mute", 1);
        }
    }

}
