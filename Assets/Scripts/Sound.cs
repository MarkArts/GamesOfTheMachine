using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Sound : MonoBehaviour {

	private int currentLevel;
	private AudioSource m_sound;

	public AudioClip[] sounds;

    public int menuBegin;
    public int menuEnd;

    public int stageOneBegin;
    public int stageOneEnd;

    public int stageTwoBegin;
    public int stageTwoEnd;

    public int stageThreeBegin;
    public int stageThreeEnd;

    private IEnumerable<int>[] ranges;


    public static Sound instance;

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            ranges = new IEnumerable<int>[4];

            ranges[0] = Enumerable.Range(menuBegin, menuEnd);
            ranges[1] = Enumerable.Range(stageOneBegin, stageOneEnd);
            ranges[2] = Enumerable.Range(stageTwoBegin, stageTwoEnd);
            ranges[3] = Enumerable.Range(stageThreeBegin, stageThreeEnd);
        }
    }

    // Use this for initialization
    void Start () {
		m_sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

        if(PlayerPrefs.GetInt("mute", 0) == 1)
        {
            m_sound.mute = true;
        }
        else
        {
            m_sound.mute = false;
        }

		if(currentLevel != Application.loadedLevel){
			changeLevel(currentLevel, Application.loadedLevel);
		}

		currentLevel = Application.loadedLevel;

		if (!m_sound.isPlaying) {
			if(Application.loadedLevel + 1 <= sounds.Length) {
                m_sound.clip = sounds[Application.loadedLevel];
                m_sound.Play();
            }
        }
	}

	void changeLevel(int currentLevel, int nextLevel){
        if(!sameStage(currentLevel, nextLevel))
        {
            m_sound.clip = sounds[Application.loadedLevel];
            m_sound.Play();
        }
	}

    bool sameStage(int x, int y )
    {
        return ranges.Select(range => range.Contains(x) && range.Contains(y)).Any(r => r == true);
    }

}
