using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece 
{
	public bool hasMoved;

	public override bool IsValidMove(int x, int y)
	{
		if (IsCastlingPosition (x, y))
		{
			return false;
		}
		return false;
	}

	bool IsCastlingPosition(int x, int y)
	{
		// is the targeted field a castling position?
		return false;
	}

	bool IsCastlingPossible(int x, int y)
	{
		if (hasMoved)
			return false;

		// Check all conditions for castling
		return true;
	}
}