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
            other.GetComponent<PlatformerCharacter2D>().die(gameObject, false);

			StartCoroutine(reset(other));

			setTimeOut(2f);
		}
	}

	IEnumerator reset(Collider2D other){
		yield return new WaitForSeconds (4f);

		deads += 1;
		gravity.setGravity (Vector2.down * 9.81f);
		gravity.allowRight = false;
        gravity.allowLeft = false;

        other.GetComponent<PlatformerCharacter2D>().resurrect(new Vector3(0, 0, 0));
        other.GetComponent<PlatformerCharacter2D>().moveable = false;

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
