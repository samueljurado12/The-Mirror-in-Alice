using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static void LoadMainMenu () {
		SceneManager.LoadScene ("main");
	}

	public static void LoadEnd () {
		SceneManager.LoadScene ("end");
	}

	public static void LoadGame () {
		SceneManager.LoadScene ("game");
	}

}
