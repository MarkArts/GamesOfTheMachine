using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public string level;

    private Animator m_Anim;

	// Use this for initialization
	void Start () {
        m_Anim = GetComponent<Animator>();

        // TODO: maybe find a better place to keep track of levels unlocked;
        PlayerPrefs.SetInt(Application.loadedLevelName, 1);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.position);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_Anim.SetTrigger("Teleport");

            PlatformerCharacter2D player = other.GetComponent<PlatformerCharacter2D>();
            player.switchLevel(level);
        }
    }
}
