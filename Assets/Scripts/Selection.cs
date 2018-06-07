using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Board), typeof(TurnManager))]
public class Selection : MonoBehaviour
{
	private Board board;
	private TurnManager turnmanager;
	private Piece selectedPiece;
	private Vector2Int selection;

	void Start()
	{
		board = GetComponent<Board> ();
		turnmanager = GetComponent<TurnManager> ();
		selection = new Vector2Int (-1, -1);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0))
		{
			UpdateSelection ();
			if (selectedPiece != null) {
				if (selectedPiece.IsValidMove (selection.x, selection.y)) {
					board.MovePiece (selectedPiece, selection);
				}
				selection = new Vector2Int (-1, -1);
				selectedPiece = null;
			} else {
				selectedPiece = board.GetPiece (selection);
				if (selectedPiece != null) {
					if (turnmanager.CompareColourCurrentPlayer (selectedPiece.Colour)) {
						//show moves
					} else {
						selectedPiece = null;
					}
				}
			}
		}
	}

	private void UpdateSelection()
	{
		if (!Camera.main)
			return;
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f, LayerMask.GetMask ("ChessPlane"))) 
		{
			selection = new Vector2Int ((int)hit.point.x, (int)hit.point.z);
		} 
		else 
		{
			selection = new Vector2Int (-1, -1);
		}
	}
}