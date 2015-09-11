using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public bool allowUp = true;
	public bool allowRight = true;
	public bool allowDown = true;
	public bool allowLeft = true;

	// Use this for initialization
	void Start () {
        Debug.Log("started gravity");
		setGravity (Vector2.down * 9.81f);
		Screen.orientation = ScreenOrientation.Landscape;
	}

	void OnGUI() {
		//GUI.Label (new Rect (10, 10, 500, 20), "Acceleration: " + Input.acceleration.x.ToString () + " : " + Input.acceleration.y.ToString ());
		//GUI.Label (new Rect (10, 30, 500, 20), "Gyro RotationRate: " + Input.gyro.rotationRate.x.ToString () + " : " + Input.gyro.rotationRate.y.ToString ());	
		//GUI.Label (new Rect (10, 50, 500, 20), "Gyro userAcceleration: " + Input.gyro.userAcceleration.x.ToString () + " : " + Input.gyro.userAcceleration.y.ToString ());
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
			float y = Input.acceleration.y;

			if(Mathf.Abs(x) < 0.5f){
				// landscape
				if(y > 0 && allowUp){
					//reverse
					setGravity(Vector3.up*9.81f);
				}
				if(y < 0 && allowDown){
					setGravity(Vector3.down*9.81f);
				}
			}else{
				// portrait
				if(x < 0 && allowLeft){
					// reverse
				setGravity(Vector3.left*9.81f);
				}
				if(x > 0 && allowRight){
					setGravity(Vector3.right*9.81f);
				}
			}
	
		#else
			if (Input.GetKeyUp (KeyCode.I) && allowUp) {
				setGravity (Vector2.up * 9.81f);
			}
			if (Input.GetKeyUp (KeyCode.L) && allowRight) {
				setGravity (Vector2.right * 9.81f);
			}
			if (Input.GetKeyUp (KeyCode.K) && allowDown) {
				setGravity (Vector2.down * 9.81f);
			}
			if (Input.GetKeyUp (KeyCode.J) && allowLeft) {
				setGravity (Vector2.left * 9.81f);
			}
		#endif
		
		
	}
}

