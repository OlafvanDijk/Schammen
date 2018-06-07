using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurnManager), typeof(GameHandler))]
public class Board : MonoBehaviour
{
	public Material white, black;
	public List<GameObject> piecesPrefabs;
	public const float TILE_SIZE = 1.0f;
	public const float TILE_OFFSET = 0.5f;
	private TurnManager turnmanager;
	private GameHandler gameHandler;
	private Array2DPiece listPiece = new Array2DPiece(8, 8);


	void Start()
	{
		turnmanager = GetComponent<TurnManager> ();
		gameHandler = GetComponent<GameHandler> ();
		SpawnAllPieces();
	}

	private void SpawnAllPieces()
	{
		listPiece = new Array2DPiece(8, 8);
		Player player = null;
		#region Player 1 //White in this case
		player = turnmanager.players [0];
		#region Pawn
		SpawnRow(0, 1, player);
		#endregion
		#region Bishops
		SpawnPiece(1, 2, 0, player);
		SpawnPiece(1, 5, 0, player);
		#endregion
		#region Knights
		SpawnPiece(2, 1, 0, player);
		SpawnPiece(2, 6, 0,player);
		#endregion
		#region Rooks
		SpawnPiece(3, 0, 0, player);
		SpawnPiece(3, 7, 0, player);
		#endregion
		#region Queen
		SpawnPiece(4, 3, 0, player);
		#endregion
		#region King
		SpawnPiece(5, 4, 0, player);
		#endregion
		#endregion

		#region Player 2 //Black in this case
		player = turnmanager.players [1];
		#region Pawn
		SpawnRow(0, 6, player);
		#endregion
		#region Bishops
		SpawnPiece(1, 2, 7, player);
		SpawnPiece(1, 5, 7, player);
		#endregion
		#region Knights
		SpawnPiece(2, 1, 7, player);
		SpawnPiece(2, 6, 7, player);
		#endregion
		#region Rooks
		SpawnPiece(3, 0, 7, player);
		SpawnPiece(3, 7, 7, player);
		#endregion
		#region Queen
		SpawnPiece(4, 3, 7, player);
		#endregion
		#region King
		SpawnPiece(5, 4, 7, player);
		#endregion
		#endregion
	}

	private void SpawnRow(int index, int y, Player player)
	{
		for (int i = 0; i < listPiece.sizeX; i++)
		{
			SpawnPiece (index, i, y, player);
		}
	}

	public void SpawnPiece(int index, int x, int y, Player player)
	{
		GameObject piece = piecesPrefabs [index];

		Vector3 tileCenter = GetTileCenter (x, y);
		tileCenter.y = piece.transform.position.y;

		GameObject go = Instantiate (piece, tileCenter, Quaternion.Euler(0,0,0)) as GameObject;
		go.transform.SetParent (transform);
		Piece c = go.GetComponent<Piece> ();
		c.SetPlayer(player);
		Material mat = null;
		switch (c.Colour)
		{
			case Side.White:
				mat = this.white;
				break;
			case Side.Black:
				mat = this.black;
				go.transform.rotation = Quaternion.Euler (0, 180, 0);
				break;
			default:
				mat = this.white;
				break;
		}
		c.SetMaterial (mat);

		c.SetPosition (x, y);
		listPiece.SetValue (x, y, c);
	}

	private Vector3 GetTileCenter(int x, int y)
	{
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSET;
		origin.z += (TILE_SIZE * y) + TILE_OFFSET;
		return origin;
	}

	public bool IsOccupied (Vector2Int position)
	{
		return listPiece.GetValue(position.x, position.y) == true;
	}

	public Piece GetPiece (Vector2Int position)
	{
		return listPiece.GetValue(position.x, position.y);
	}

	public void MovePiece(Piece piece, Vector2Int position)
	{
		if (IsOccupied (position)) {
			Piece other = GetPiece (position);
			if (other.IsSameColour (piece.Colour)) {
				return;
			} else {
				Move (piece, position);
				Piece otherPiece = other.GetComponent<Piece>();
				otherPiece.DestoryPiece ();
				gameHandler.CheckGameOver ();
			}
		} else
		{
			Move (piece, position);
		}
	}

	private void Move(Piece piece, Vector2Int position)
	{
		listPiece.SetValue (position.x, position.y, piece);
		Transform pieceTransform = piece.gameObject.transform;
		listPiece.SetValue (piece.Position.x, piece.Position.y, null);
		Vector3 tileCenter = GetTileCenter (position.x, position.y);
		tileCenter.y = pieceTransform.position.y;
		pieceTransform.position = tileCenter;
		piece.SetPosition (position.x, position.y);
		turnmanager.NextPlayer ();
	}
}