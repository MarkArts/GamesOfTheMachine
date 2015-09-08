using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	public class WalkControlInput : InputBehaviour {
		public void input(PlatformerCharacter2D cha){
			cha.speedX = CrossPlatformInputManager.GetAxis("Horizontal");
		}
	}
}