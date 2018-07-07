using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    [SerializeField, Range(0, 1)]
    private float fadeTime, maxVolume;

    private AudioSource goodMusic, badMusic;
    private bool lastStatus;

	// Use this for initialization
	void Start () {
        goodMusic = GetComponentsInChildren<AudioSource>()[0];
        badMusic = GetComponentsInChildren<AudioSource>()[1];
        lastStatus = upperScreen(); ;
        setMute();
    }
	
	// Update is called once per frame
	void Update () {
        if (lastStatus != upperScreen()) {
            lastStatus = upperScreen();
            swapMusic();
        }
    }

    private void setMute() {
        goodMusic.volume = upperScreen() ? maxVolume : 0;
        badMusic.volume = !upperScreen() ? maxVolume : 0;
    }

    private void swapMusic() {
        IEnumerator fadeIn;
        IEnumerator fadeOut;
        if (lastStatus) {
            fadeIn = MusicFader.fadeIn(goodMusic, fadeTime, maxVolume);
            fadeOut = MusicFader.fadeOut(badMusic, fadeTime);
        } else {
            fadeIn = MusicFader.fadeIn(badMusic, fadeTime, maxVolume);
            fadeOut = MusicFader.fadeOut(goodMusic, fadeTime);
        }
        StartCoroutine(fadeIn);
        StartCoroutine(fadeOut);
    }

    private bool upperScreen() {
        return Swapper.getUpperScreenCanCatch();
    }

}
