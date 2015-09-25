using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
            other.GetComponent<PlatformerCharacter2D>().switchLevel(scene);
		}
	}

}
