using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    [SerializeField]
    private LevelManager lvlmngr;
    [SerializeField]
    private AudioClip clip;

    private AudioSource audioPlayer;

    private void Start() {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void loadGameSelector() {
        lvlmngr.LoadScene("01b_GameModeSelector");
    }

    public void playAudio() {
        audioPlayer.PlayOneShot(clip);
    }

}
