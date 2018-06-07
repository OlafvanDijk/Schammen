using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Moves/Straight and Diagonal")]
public class StraightAndDiagonalMove : MoveDescription {

	public List<MoveDescription> moves;

	public override bool CanMove (Vector2Int Position, int deltaX, int deltaY, out List<Vector2Int> interveningSpaces)
	{

		interveningSpaces = null;
		bool canMove = false;
		foreach (MoveDescription move in moves)
		{
			if (move.CanMove (Position, deltaX, deltaY, out interveningSpaces))
			{
				canMove = true;
			}
		}
		return canMove;
	}
		
}
