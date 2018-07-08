using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeService : MonoBehaviour {

	public static int player1Life = 3, player2Life = 3;

	public Life vida1Player1;
	public Life vida2Player1;
	public Life vida3Player1;
	public Life vida1Player2;
	public Life vida2Player2;
	public Life vida3Player2;


	public void player1GainsLife () {
		player1Life++;
	}

	public void player2GainsLife () {
		player2Life++;
	}

	public bool player1LosesLife () {
		bool playerHasZeroLives = false;
		player1Life--;
		if (player1Life == 0) {
			playerHasZeroLives = true;
			vida1Player1.SwapSprites ();
		} else if (player1Life == 1) {
			vida2Player1.SwapSprites ();
		} else if (player1Life == 2) {
			vida3Player1.SwapSprites ();
		}
		return playerHasZeroLives;
	}

	public bool player2LosesLife () {
		bool playerHasZeroLives = false;
		player2Life--;
		if (player2Life == 0) {
			playerHasZeroLives = true;
			vida1Player2.SwapSprites ();
		} else if (player2Life == 1) {
			vida2Player2.SwapSprites ();
		} else if (player2Life == 2) {
			vida3Player2.SwapSprites ();
		}
		return playerHasZeroLives;
	}
}
