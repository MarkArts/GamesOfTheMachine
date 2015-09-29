using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
        {
            Application.LoadLevel("main");
        }
	}
}
