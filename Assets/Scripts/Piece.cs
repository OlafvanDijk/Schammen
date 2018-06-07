using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour 
{
	public Vector2Int Position;
	public MoveDescription Moves;
	public Side Colour;
	public Player player;

	public Board board;

	void Start()
	{
		board = GetComponentInParent<Board> ();
	}

	public virtual bool IsValidMove(int x, int y)
	{
		Piece onTarget = board.GetPiece (new Vector2Int (x, y));
		if (onTarget != null)
		{
			if ((onTarget.Colour) == Colour)
				return false;
		}

		int deltaX = x - Position.x;
		int deltaY = y - Position.y;
		if (this.Colour == Side.Black)
		{
			deltaX = FlipNumber (deltaX);
			deltaY = FlipNumber (deltaY);
		}
		List<Vector2Int> interveningSpaces;
		bool canMove = Moves.CanMove (Position, deltaX, deltaY, out interveningSpaces);

		if (!canMove)
		{
			return false;
		}

		for (int i = 0; i < interveningSpaces.Count; i++)
		{
			if (board.IsOccupied (interveningSpaces [i]))
			{
				return false;
			}
		}
		return true;
	}

	public void SetPosition (int x, int y)
	{
		this.Position = new Vector2Int (x, y);
	}

	public bool IsSameColour(Side colour)
	{
		return this.Colour == colour;
	}

	public void SetMaterial(Material mat)
	{
		Renderer rend = GetComponent<Renderer> ();
		if (rend != null)
		{
			rend.material = mat;
		}
		CheckChildren (mat);
	}

	private void CheckChildren(Material mat)
	{
		Renderer[] rend = GetComponentsInChildren<Renderer> ();
		if (rend.Length > 0)
		{
			foreach (Renderer re in rend)
			{
				re.material = mat;
			}
		}
	}

	private int FlipNumber(int number)
	{
		if (number > 0 || number < 0)
		{
			number *= -1;
		}
		return number;
	}

	public void SetPlayer(Player player)
	{
		this.player = player;
		this.Colour = player.Colour;
	}

	public void DestoryPiece()
	{
		this.player.RemovePiece();
		Destroy (this.gameObject);
	}
}