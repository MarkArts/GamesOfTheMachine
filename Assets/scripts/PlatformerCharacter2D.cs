using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlatformerCharacter2D : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
//    [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .05f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private SpriteRenderer m_renderer;

	public GameObject bloodSplat;

	public bool canControl;
	public bool moveable = true;

	private bool death = false;

    public GameObject[] bodyParts;

	//input
	public InputComposite inputs = new InputComposite();
	public bool jump { get; set; }
	public bool jumping { get; private set; }
	public bool crouch { get; set; }
	public float speedX { get; set; }


	void Start(){
		inputs.addInput (new JumpInput ());
		if (canControl) {
			inputs.addInput (new WalkControlInput ());
		} else {
			inputs.addInput (new WalkRightInput ());
		}
		//	inputs.addInput (new CrouchInput ());
	}

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_renderer = GetComponent<SpriteRenderer> ();
    }

    private AnimatorStateInfo lastAnimeState;
	void Update(){

        lastAnimeState = m_Anim.GetCurrentAnimatorStateInfo(0);

        // set the rotation of the player according to the current gravity 
        transform.rotation = Quaternion.AngleAxis (Gravity.angle(), new Vector3 (0, 0, 1));

		// check if we are touching the ground 
		m_Grounded = isGrounded();
		m_Anim.SetBool("Ground", m_Grounded);

		// Set the vertical animation
		m_Anim.SetFloat("vSpeed", Gravity.gravitize(m_Rigidbody2D.velocity).y);

		if (moveable) {
			inputs.input (this);
		}

		// If crouching and trying to stand up, check to see if the character can stand up
		if (!crouch && m_Anim.GetBool("Crouch") && !canStand())
		{
			crouch = true;
		}
		// Set whether or not the character is crouching in the animator
		m_Anim.SetBool("Crouch", crouch);

		// Reduce the speed if crouching by the crouchSpeed multiplier
		float modSpeedX = (crouch ? speedX*m_CrouchSpeed : speedX);
	
		//only control the player if grounded or airControl is turned on
		if (m_Grounded)
		{				
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			m_Anim.SetFloat("Speed", Mathf.Abs(modSpeedX));
			
			// Move the character
			m_Rigidbody2D.velocity = Gravity.gravitize(new Vector2((modSpeedX*m_MaxSpeed), 0f));
			
			// if the moving direction of the character changes
			if ( (modSpeedX > 0 && !m_FacingRight) || (modSpeedX < 0 && m_FacingRight) )
			{
				Flip();
			}
		}

		if (Math.Round(Gravity.gravitize (m_Rigidbody2D.velocity).y, 2) > 0) {
			jumping = false;
		}

		if (m_Grounded && jump && !jumping)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			jumping = true;
			m_Anim.SetBool("Ground", false);
			m_Rigidbody2D.AddForce(Gravity.gravitize(new Vector2(0f, m_JumpForce)));
		}

		jump = false;

        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("entry"))
        {
            m_Rigidbody2D.velocity = Vector2.zero;
        }
    }

	private bool canStand(){
		return !Physics2D.OverlapCircle (m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround);
	}

	private bool isGrounded(){
		// we can never be grounded if we are moving upwards
		if (Math.Round(Gravity.gravitize (m_Rigidbody2D.velocity).y, 2) > 0){
			return false;
		}

		Collider2D[] colliders = Physics2D.OverlapCircleAll (m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders [i].gameObject != gameObject)
				return true;
		}

		return false;
	}

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void switchLevel(String scene)
    {
        m_Anim.SetTrigger("Teleport");
        StartCoroutine(loadLevel(scene));
    }

    IEnumerator loadLevel(String scene)
    {
        yield return new WaitForSeconds(1.1f);

        Application.LoadLevel(scene);
    }

	public void die(GameObject killer, bool reset = true)
    {
		if (!death) {
			this.onDeath (killer, reset);
		}
	}

	private void onDeath(GameObject killer, bool reset = true)
    {
		death = true;

        if(killer.tag == "Fire")
        {
            m_Anim.SetTrigger("Burn");
            m_MaxSpeed = 2.5f;

            if (reset)
                Invoke("reset", 1.1f);
        }
        else
        {

            GameObject blood = (GameObject)Instantiate(bloodSplat, transform.position, Quaternion.identity);

            Vector2 v = m_Rigidbody2D.velocity;
            if (v.magnitude > 4f)
            {
                v = v.normalized * 4f;
            }

            blood.GetComponent<BloodParticles>().initVelocity = v;

            foreach (GameObject part in bodyParts)
            {
                GameObject _part = (GameObject)Instantiate(part, transform.position, Quaternion.identity);
                _part.GetComponent<Rigidbody2D>().velocity = m_Rigidbody2D.velocity * 0.5f;
            }

            m_Rigidbody2D.isKinematic = true;
            m_Rigidbody2D.velocity = Vector2.zero;
            moveable = false;
            speedX = 0f;
            m_renderer.enabled = false;

            if (reset)
                Invoke("reset", 4f);
        }
	}

    public void resurrect(Vector2 position)
    {
        m_Rigidbody2D.isKinematic = false;
        moveable = true;
        m_renderer.enabled = true;
        m_Rigidbody2D.velocity = Vector2.zero;
        transform.position = position;
        death = false;
    }

	void reset(){
		Application.LoadLevel(Application.loadedLevelName);
	}

}
