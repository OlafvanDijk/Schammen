using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Moves/Straight Move")]
public class StraightMove : MoveDescription 
{

	public override bool CanMove (Vector2Int Position, int deltaX, int deltaY, out List<Vector2Int> interveningSpaces)
	{
		interveningSpaces = new List<Vector2Int>();

		return	((int)Mathf.Abs (deltaX) > 0 && deltaY == 0) || ((int)Mathf.Abs (deltaY) > 0 && deltaX == 0);
	}
}
