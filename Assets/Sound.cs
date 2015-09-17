using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound : MonoBehaviour {

	private string currentLevel;
	private AudioSource m_sound;

	public AudioClip[] sounds;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		m_sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentLevel != Application.loadedLevelName){
			changeLevel(currentLevel, Application.loadedLevelName);
		}

		currentLevel = Application.loadedLevelName;

		if (!m_sound.isPlaying) {
			Debug.Log (m_sound.isPlaying);

			if(Application.loadedLevel + 1 <= sounds.Length)
				m_sound.clip = sounds[Application.loadedLevel];

			m_sound.Play();
		}
	}

	void changeLevel(string currentLevel, string nextLevel){

	}
}
