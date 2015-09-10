using UnityEngine;
using System.Collections;

using System.Collections.Generic;

namespace UnityStandardAssets._2D
{
	public class InputComposite : InputBehaviour {
		private List<InputBehaviour> inputs = new List<InputBehaviour> ();

		public void input(PlatformerCharacter2D cha){
			inputs.ForEach (i => i.input (cha));
		}

		public void addInput(InputBehaviour input){
			inputs.Add (input);
		}

		public void removeInput(InputBehaviour input){
			inputs.Remove (input);
		}
	}
}