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
				Invoke("reset", 1f);
            }
        }

		void reset(Collider2D other){
			Application.LoadLevel(Application.loadedLevelName);
		}

    }
}
