using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {
	public PlayerCollisionBehaviour player;
	public LifeService lifeService;

	public bool isCoop = false;
	void Start() {
		lifeService = FindObjectOfType<LifeService> ();
	}

	void OnTriggerEnter2D (Collider2D collision) {
		ScoreService scoreService = ScoreService.getInstance ();
		Debug.Log (collision.tag);
		if (collision.gameObject.CompareTag ("Player1")) {
			SceneManager.LoadScene (isCoop? "Cinematica":"GanarFalsa");
		} else if (collision.gameObject.CompareTag ("Player2")) {
			SceneManager.LoadScene (isCoop? "Cinematica":"GanarReal");
		} else if (collision.gameObject.CompareTag ("Target")) {
			Debug.Log ("Missed");
			PickableObject target = collision.gameObject.GetComponent<PickableObject> ();
			if (target.isCatchable != player.isCatcher) {
				if (player.isPlayerOne) {
					scoreService.increasePlayer1Score (target.score);
				} else {
					scoreService.increasePlayer2Score (target.score);
				}

			} else if (target.canDamage) {
				if (player.isPlayerOne) {
					scoreService.decreasePlayer1Score (target.score);
					lifeService.player1LosesLife ();
				} else {
					scoreService.decreasePlayer2Score (target.score);
					lifeService.player2LosesLife ();
				}
				target.canDamage = false;

				Swapper.upperScreenCanCatch =! Swapper.upperScreenCanCatch;
				Destroy (collision.gameObject);
			}
		}



	}
}
