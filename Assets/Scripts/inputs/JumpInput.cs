using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class JumpInput : InputBehaviour {
	public void input(PlatformerCharacter2D cha){
		#if UNITY_IPHONE || UNITY_ANDROID
			cha.jump = !cha.jump && cha.m_Grounded && Input.touchCount > 0;
		#else
			cha.jump = !cha.jump && cha.m_Grounded && CrossPlatformInputManager.GetButtonDown("Jump");
		#endif
	}
}