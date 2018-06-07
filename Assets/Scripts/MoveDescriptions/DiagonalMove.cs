using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Moves/Diagonal")]
public class DiagonalMove : MoveDescription
{
	public override bool CanMove (Vector2Int Position, int deltaX, int deltaY, out List<Vector2Int> interveningSpaces)
	{
		interveningSpaces = null;
		int deltaXR = (int)Mathf.Abs (deltaX);
		int deltaYR = (int)Mathf.Abs (deltaY);
		if (deltaXR == deltaYR)
		{
			//Zoek interveningSpaces
			interveningSpaces = new List<Vector2Int>();
			return true;
		}
		return false;
	}
}