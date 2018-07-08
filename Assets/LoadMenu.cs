using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour {

	void Start () {
		Invoke ("Load", 6);
	}

	private void Load () {
		LevelManager.LoadMainMenu ();
	}

}
