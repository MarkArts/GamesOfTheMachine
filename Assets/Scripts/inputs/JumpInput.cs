using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
	
namespace UnityStandardAssets._2D
{
	public class JumpInput : InputBehaviour {
		public void input(PlatformerCharacter2D cha){
			#if UNITY_IPHONE || UNITY_ANDROID
				cha.jump = Input.touchCount > 0 && cha.m_Grounded;
			#else
				cha.jump = !cha.jump && cha.m_Grounded && CrossPlatformInputManager.GetButtonDown("Jump");
			#endif
		}
	}
}
