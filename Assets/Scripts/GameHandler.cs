using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurnManager))]
public class GameHandler : MonoBehaviour {

	private TurnManager turnManager;

	void Start()
	{
		this.turnManager = GetComponent<TurnManager> ();
	}


	public void CheckGameOver()
	{
		List<PlayersOver> playersOver = new List<PlayersOver> ();
		for (int i = 0; i < turnManager.players.Count; i++)
		{
			if (!turnManager.players [i].GameOver())
			{
				playersOver.Add (new PlayersOver(i, turnManager.players [i]));
			}
		}

		if (playersOver.Count == 1)
		{
			//Debug.Log ("Player " + playersOver[0].index + " has won!");
		}
	}
}