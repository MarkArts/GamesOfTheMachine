using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("started gravity");
		setGravity (Vector2.down * 9.81f);
		//Screen.orientation = ScreenOrientation.Landscape;
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
			float x = Input.acceleration.x;
		Debug.Log (x);

		GUI.Label(new Rect(10,10,100,100), x.ToString());

			if((x > 315 && x <= 360) || (x >=0 && x <= 45)){
				setGravity(Vector2.down * 9.81f);
			}
			if(x > 45 && x <= 135){
				setGravity(Vector2.right * 9.81f);
			}
			if(x > 135  && x <= 225){
				setGravity(Vector2.down * 9.81f);
			}
			if(x > 225 && x <= 315){
				setGravity(Vector2.up * 9.81f);
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

