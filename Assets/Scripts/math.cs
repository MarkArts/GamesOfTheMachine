using UnityEngine;
using System.Collections;

public static class math {
	public static Directions getDirection(Vector2 vector){
		if(vector.x > 0 && Mathf.Abs(vector.x) > Mathf.Abs(vector.y)){
			return Directions.right;
		}

		if(vector.x < 0 && Mathf.Abs(vector.x) > Mathf.Abs(vector.y)){
			return Directions.left;
		}

		if(vector.y > 0 && Mathf.Abs(vector.y) > Mathf.Abs(vector.x)){
			return Directions.up;
		}

		if(vector.y < 0 && Mathf.Abs(vector.y) > Mathf.Abs(vector.x)){
			return Directions.down;
		}

		return Directions.none;
	}
}

public enum Directions{
	up,
	right,
	down,
	left,
	none
}