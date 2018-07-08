using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    [SerializeField]
    private LevelManager lvlmngr;

	public void loadGameSelector() {
        lvlmngr.LoadScene("01b_GameModeSelector");
    }
}
