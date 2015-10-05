using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0f, 0f, speed));
	}
}
