using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
	public class WalkRightInput : InputBehaviour {
		public void input(PlatformerCharacter2D cha){
			cha.speedX = 1;
		}
	}
}