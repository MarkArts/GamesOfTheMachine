using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider2D))]
public class fire : MonoBehaviour {

	private Animator m_Anim;
	private BoxCollider2D m_colider;

	public float onTime;
	public float offTime;

	private void Awake()
	{
		// Setting up references.
		m_Anim = GetComponent<Animator>();
		m_colider = GetComponent<BoxCollider2D> ();

		this.startFire ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {

	}

	void startFire(){
		m_Anim.SetTrigger ("start");
		Invoke ("enableCollision", 0.5f);;
	}

	void enableCollision(){
		m_colider.enabled = true;
		Invoke ("disableCollision", onTime);
	}

	void disableCollision(){
		m_Anim.SetTrigger ("stop");
		m_colider.enabled = false;
		Invoke ("startFire", offTime);;
	}
}
