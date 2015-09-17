using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class WalkControlInput : InputBehaviour {
	public void input(PlatformerCharacter2D cha){

		#if UNITY_IPHONE || UNITY_ANDROID
			float angle = Gravity.tiltAngle();
			cha.speedX = (angle > 0.05f || angle < 0.05f) ? 0f : angle*2;
		#else
			cha.speedX = CrossPlatformInputManager.GetAxis("Horizontal");
		#endif
	}
}