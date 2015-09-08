using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("started gravity");
		setGravity (Vector2.down * 9.81f);
	}

	void setGravity(Vector2 grav){
		Physics2D.gravity = grav;
	}

	public static float angle(){
		return (float)(Mathf.Atan2(Physics2D.gravity.x, Physics2D.gravity.y * -1) * ( 180 / Mathf.PI ));
	}

	public static Vector2 gravitize(Vector2 vect){
		float ca = Mathf.Cos(Gravity.angle() * (Mathf.PI / 180));
		float sa = Mathf.Sin(Gravity.angle() * (Mathf.PI / 180));
		return new Vector2 (ca * vect.x - sa * vect.y, sa * vect.x + ca * vect.y);
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
			if (Input.GetKeyUp (KeyCode.I)) {
				setGravity (Vector2.up * 9.81f);
			}
			if (Input.GetKeyUp (KeyCode.L)) {
				setGravity (Vector2.right * 9.81f);
			}
			if (Input.GetKeyUp (KeyCode.K)) {
				setGravity (Vector2.down * 9.81f);
			}
			if (Input.GetKeyUp (KeyCode.J)) {
				setGravity (Vector2.left * 9.81f);
			}
		#endif
		
		
	}
}
