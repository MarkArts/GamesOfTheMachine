using UnityEngine;
using System.Collections;

public class CrouchInput : InputBehaviour {
	public void input(PlatformerCharacter2D cha){
		cha.crouch = Input.GetKey(KeyCode.LeftControl);
	}
}