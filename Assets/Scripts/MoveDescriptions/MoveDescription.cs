using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveDescription : ScriptableObject
{
	public abstract bool CanMove (Vector2Int Position, int deltaX, int deltaY, out List<Vector2Int> interveningSpaces);
}
