using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("muerto");
		//SceneManager.LoadScene ("");

	}
}
