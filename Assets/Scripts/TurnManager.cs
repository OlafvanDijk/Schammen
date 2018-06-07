using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	public List<Player> players;
	private int currentPlayer = 0;

	// Use this for initialization
	void Start () {
		currentPlayer = 0;
		players [currentPlayer].OnStartTurn ();
	}
	
	public void NextPlayer()
	{
		//Get next Player
		currentPlayer++;
		if (currentPlayer >= players.Count)
		{
			currentPlayer = 0;
		}

		//Start new Turn
		players[currentPlayer].OnStartTurn();
	}

	public bool CompareColourCurrentPlayer(Side colour)
	{
		return colour == players [currentPlayer].Colour;
	}

	public Side GetPlayerColour (int index)
	{
		if (players.Count - 1 >= index) {
			return players [index].Colour;
		}
		return Side.White;
	}
}
