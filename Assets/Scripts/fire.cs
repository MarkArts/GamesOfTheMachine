using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

	private Animator m_Anim;
	private BoxCollider2D m_colider;

	private void Awake()
	{
		// Setting up references.
		m_Anim = GetComponent<Animator>();
		m_colider = GetComponent<BoxCollider2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}

	private float lastSecond = 0f;
	// Update is called once per frame
	void Update () {

		float currentSecond = Mathf.Round (Time.time);

		if (lastSecond != currentSecond && currentSecond % 5 == 0) {
			this.startFire();
			Invoke("enableCollision", 0.5f);
		} 

		lastSecond = Mathf.Round (Time.time);
	}

	void startFire(){
		m_Anim.SetTrigger ("start");
	}

	void enableCollision(){
		m_colider.enabled = true;
		Invoke ("disableCollision",1.5f);
	}

	void disableCollision(){
		m_colider.enabled = false;
	}
}
