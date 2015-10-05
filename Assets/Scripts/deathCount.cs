using UnityEngine;
using System.Collections;

public class deathCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("deaths", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
