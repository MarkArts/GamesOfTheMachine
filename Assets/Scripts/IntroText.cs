using UnityEngine;
using System.Collections;

public class IntroText : MonoBehaviour {
	
	private bool canStart = false;
	
	private TextMesh m_text;
	private Gravity gravity;
	
	// Use this for initialization
	void Start () {
		m_text = GetComponent<TextMesh> ();
		gravity = GameObject.FindObjectOfType<Gravity> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!canStart) {
			canStart = (Gravity.getOrientation() == Orientation.down);
			
			if(canStart){
				Invoke("timIsYourBestFreind", 2f);
			}
			
			return;
		}
	}
	
	void timIsYourBestFreind(){
		m_text.text = "Tim is your very best friend";
		Invoke ("andYouLoveHim", 4f);
	}
	
	void andYouLoveHim(){
		m_text.text = "And you love him very very much";
		Invoke ("nowTurn", 4f);
	}
	
	void nowTurn(){
		m_text.text = "Now would you kindly turn your screen to the right";
		gravity.allowRight = true;
		gravity.allowLeft = true;
	}
	
	public void	great(){
		m_text.text = "NICE! I do not like Tim";
		Invoke ("notLeft", 4f);
	}
	
	void notLeft(){
		m_text.text = "Good thing you didnt turn your screen left though";
		Invoke ("doItAgain", 5f);
	}
	
	void doItAgain(){
		m_text.text = "Now do it again!!!!!!";
		gravity.allowRight = true;
		gravity.allowLeft = true;
	}
	
	public void andAgain(){
		m_text.text = ":D :D !!!!!AND AGAIN!!!!! :D :D";
		Invoke ("enableGrav", 1f);
	}
	
	void enableGrav(){
		gravity.allowRight = true;
		gravity.allowLeft = true;
	}
}
