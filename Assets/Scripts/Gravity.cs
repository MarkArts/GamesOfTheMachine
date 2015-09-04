using UnityEngine;
using System.Collections;

public enum Rotations {
	up,
	right,
	left,
	down
}

public class Gravity : MonoBehaviour {
	
	private Rotations currentRotations;

	// Use this for initialization
	void Start () {
        Debug.Log("started gravity");
		currentRotations = Rotations.down;
	}

	private void rotateWorld(Rotations rotation){
		float angle = 0;
		if (rotation == currentRotations) {
			Debug.Log ("same rotation");
			return;
		}

		if (currentRotations == Rotations.down) {
			switch(rotation){
				case Rotations.right:
					angle = -90; 
					break;
				case Rotations.left:
					angle = 90;
					break;
				case Rotations.up:
					angle = 180;
					break;
			}
		}

		if (currentRotations == Rotations.left) {
			switch(rotation){
				case Rotations.up:
					angle = 90; 
					break;
				case Rotations.right:
					angle = 180;
					break;
				case Rotations.down:
					angle = -90;
					break;
			}
		}

		if (currentRotations == Rotations.up) {
			switch(rotation){
				case Rotations.right:
					angle = 90; 
					break;
				case Rotations.down:
					angle = 180;
					break;
				case Rotations.left:
					angle = -90;
					break;
			}
		}

		if (currentRotations == Rotations.right) {
			switch(rotation){
				case Rotations.down:
					angle = 90; 
					break;
				case Rotations.left:
					angle = 180;
					break;
				case Rotations.up:
					angle = -90;
					break;
			}
		}

		Vector3 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		
		GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();
		foreach (GameObject go in allObjects) {
			if (go.activeInHierarchy && go.transform.parent == null && !go.CompareTag ("MainCamera") && !go.CompareTag ("Player") && !go.CompareTag ("noRotate")) {
				go.transform.RotateAround (playerPos, new Vector3(0,0,1), angle);
			}
		}

		currentRotations = rotation;
	}

	// Update is called once per frame
	void Update () {
		
		#if UNITY_IPHONE || UNITY_ANDROID
			switch(Screen.orientation){
				case ScreenOrientation.LandscapeRight:
					rotateWorld(Rotations.up);
					break;
				case ScreenOrientation.PortraitUpsideDown:
					rotateWorld(Rotations.left);
					break;
				case ScreenOrientation.Landscape:
					rotateWorld(Rotations.down);
					break;
				case ScreenOrientation.Portrait:
					rotateWorld(Rotations.right);
					break;
				default:
					break;
			}
		#else
			if (Input.GetKeyUp (KeyCode.W)) {
				rotateWorld(Rotations.up);
			}
			if (Input.GetKeyUp (KeyCode.D)) {
				rotateWorld(Rotations.right);
			}
			if (Input.GetKeyUp (KeyCode.S)) {
				rotateWorld(Rotations.down);
			}
			if (Input.GetKeyUp (KeyCode.A)) {
				rotateWorld(Rotations.left);
			}
		#endif
		
		
	}
}
