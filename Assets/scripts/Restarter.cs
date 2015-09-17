using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
				other.GetComponent<Rigidbody2D>().isKinematic = true;
				other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				Invoke("reset", 1f);
            }
        }

		void reset(){
			Application.LoadLevel(Application.loadedLevelName);
		}

    }
}
