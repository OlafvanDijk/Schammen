using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersOver
{
	public int index { get; set; }
	public Player player { get; set; }

	public PlayersOver(int index, Player player)
	{
		this.index = index;
		this.player = player;
	}
}