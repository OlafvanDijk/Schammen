using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Moves/Picture")]
public class EditorDefinedMove : MoveDescription
{
	//2darray
	public Array2DBool MySerializableArray2D = new Array2DBool(7, 7);

	public override bool CanMove (Vector2Int Position, int deltaX, int deltaY, out List<Vector2Int> interveningSpaces)
	{
		int xMiddle = Mathf.RoundToInt (MySerializableArray2D.sizeX / 2);
		int yMiddle = Mathf.RoundToInt (MySerializableArray2D.sizeY / 2);
		interveningSpaces = new List<Vector2Int>();
		return MySerializableArray2D.GetValue(xMiddle + deltaX, yMiddle + deltaY);
	}
}
