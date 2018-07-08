using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.CompareTag ("Player1")) {
			SceneManager.LoadScene ("GanarFalsa");
		} else {
			SceneManager.LoadScene ("GanarReal");
		}


	}
}
