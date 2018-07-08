using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeService : MonoBehaviour {

	public static int player1Life = 3, player2Life = 3;

	public bool isCoop = false;

	public static float timeSinceLastHit1 = 0;
	public static float timeSinceLastHit2 = 0;

	public Life vida1Player1;
	public Life vida2Player1;
	public Life vida3Player1;
	public Life vida1Player2;
	public Life vida2Player2;
	public Life vida3Player2;


	void Update() {
		timeSinceLastHit1 += Time.deltaTime;
		timeSinceLastHit2 += Time.deltaTime;
	}

	public void player1GainsLife () {
		player1Life++;
	}

	public void player2GainsLife () {
		player2Life++;
	}

	public bool player1LosesLife () {
		bool playerHasZeroLives = false;

		if (timeSinceLastHit1 > 2) {
			player1Life--;

			if (player1Life == 0) {
				playerHasZeroLives = true;
				DifficultyService.difficulty = 2;
				LifeService.player1Life = 3;
				LifeService.player2Life = 3;
				SceneManager.LoadScene (isCoop? "Cinematica":"GanarFalsa");
				vida1Player1.SwapSprites ();
			} else if (player1Life == 1) {
				vida2Player1.SwapSprites ();
			} else if (player1Life == 2) {
				vida3Player1.SwapSprites ();
			}
			timeSinceLastHit1 = 0;
		}
		return playerHasZeroLives;
	}

	public bool player2LosesLife () {
		bool playerHasZeroLives = false;
		if (timeSinceLastHit2 > 2) {
			player2Life--;
			if (player2Life == 0) {

				DifficultyService.difficulty = 2;
				LifeService.player1Life = 3;
				LifeService.player2Life = 3;
				SceneManager.LoadScene (isCoop? "Cinematica":"GanarReal");
				playerHasZeroLives = true;
				vida1Player2.SwapSprites ();
			} else if (player2Life == 1) {
				vida2Player2.SwapSprites ();
			} else if (player2Life == 2) {
				vida3Player2.SwapSprites ();
			}
			timeSinceLastHit2 = 0;
		}
		return playerHasZeroLives;
	}
}
