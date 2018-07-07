using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour {


	void Start () {
		Invoke ("loadMenu", 3);	
	}

	private void loadMenu () {
		LevelManager.LoadMainMenu ();
	}
}
