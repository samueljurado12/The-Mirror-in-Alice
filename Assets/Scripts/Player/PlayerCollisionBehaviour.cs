using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour {

	public bool isCatcher;
	public bool isPlayerOne;
	ScoreService scoreService;
	LifeService lifeService;

	// Use this for initialization
	void Start () {
		scoreService = ScoreService.getInstance ();
		lifeService = FindObjectOfType<LifeService> ();
	}

	private void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.CompareTag ("Target")) {
			Debug.Log ("Target hitted!");

			PickableObject target = collision.gameObject.GetComponent<PickableObject> ();
			bool playerHasZeroLives = false;

			if (target.isCatchable == isCatcher) {
				if (isPlayerOne) {
					scoreService.increasePlayer1Score (target.score);
				} else {
					scoreService.increasePlayer2Score (target.score);
				}

			} else {
				if (isPlayerOne) {
					scoreService.decreasePlayer1Score (target.score);
					playerHasZeroLives = lifeService.player1LosesLife ();

				} else {
					scoreService.decreasePlayer2Score (target.score);
					playerHasZeroLives = lifeService.player2LosesLife ();
				}

				Debug.Log ("Swap");

				Swapper.upperScreenCanCatch = !Swapper.upperScreenCanCatch;

				if (playerHasZeroLives) {/*Game Over*/
				}
			}
			target.PlaySound ();
			Destroy (collision.gameObject);
		}
	}
}
