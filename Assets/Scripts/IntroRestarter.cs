using UnityEngine;
using System.Collections;

public class IntroRestarter : MonoBehaviour {
	
	private int deads = 0;
	private Gravity gravity;
	private IntroText introText;

	private bool timeOut = false;

	void Start () {
		gravity = GameObject.FindObjectOfType<Gravity> ();
		introText = GameObject.FindObjectOfType<IntroText> ();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && !timeOut)
		{
			StartCoroutine(reset(other));

			other.GetComponent<Rigidbody2D>().isKinematic = true;

			setTimeOut(2f);
		}
	}

	IEnumerator reset(Collider2D other){
		yield return new WaitForSeconds (1f);

		deads += 1;
		gravity.setGravity (Vector2.down * 9.81f);
		gravity.allowRight = false;
		
		other.transform.position = new Vector3(0.243f, -2.508f,0);
		other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		other.GetComponent<Rigidbody2D>().isKinematic = false;

		if (deads == 1) {
			introText.great();
		}else{
			introText.andAgain();
		}
	}

	void setTimeOut(float sec){
		timeOut = true;
		Invoke ("endTimeOut", sec);
	}

	void endTimeOut(){
		timeOut = false;
	}
}
