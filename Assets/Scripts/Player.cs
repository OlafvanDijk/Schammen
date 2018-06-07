using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Side Colour;
	public Transform cameraTransform;
	public TurnCamera turnCamera;
	private int numberOfPieces;

	void Start()
	{
		numberOfPieces = 0;
	}

	public void OnStartTurn()
	{
		//do something
		turnCamera.SetCameraPosRot(cameraTransform);
	}

	public void RemovePiece()
	{
		numberOfPieces--;
	}

	public bool GameOver()
	{
		return numberOfPieces == 0;
	}
}
