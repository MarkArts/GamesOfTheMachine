using System;
using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			PlatformerCharacter2D player = other.GetComponent<PlatformerCharacter2D>();
			player.die(gameObject);
        }
    }
}