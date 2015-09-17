using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class WalkControlInput : InputBehaviour {
	public void input(PlatformerCharacter2D cha){

		#if UNITY_IPHONE || UNITY_ANDROID
			cha.speedX = Gravity.tiltAngle();
		#else
			cha.speedX = CrossPlatformInputManager.GetAxis("Horizontal");
		#endif
	}
}