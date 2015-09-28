using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class WalkControlInput : InputBehaviour {
	public void input(PlatformerCharacter2D cha){

		#if UNITY_IPHONE || UNITY_ANDROID
		float angle = Gravity.tiltAngle();

        if (angle > 0.10f)
            cha.speedX = -1f;
        else if (angle < -0.10f)
            cha.speedX = 1f;
        else
            cha.speedX = 0f;
		#else
		cha.speedX = CrossPlatformInputManager.GetAxis("Horizontal");
		#endif
	}
}