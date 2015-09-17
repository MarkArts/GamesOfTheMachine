using UnityEngine;
using System.Collections;

public class WalkRightInput : InputBehaviour {
	public void input(PlatformerCharacter2D cha){
		cha.speedX = 1;
	}
}
