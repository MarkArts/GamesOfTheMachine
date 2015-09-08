using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
	
namespace UnityStandardAssets._2D
{
	public class JumpInput : InputBehaviour {
		public void input(PlatformerCharacter2D cha){
			if (!cha.jump && cha.m_Grounded)
			{
				// Read the jump input in Update so button presses aren't missed.
				cha.jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
		}
	}
}
