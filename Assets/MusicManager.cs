using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource goodMusic, badMusic;

	// Use this for initialization
	void Start () {
        goodMusic = GetComponentsInChildren<AudioSource>()[0];
        badMusic = GetComponentsInChildren<AudioSource>()[1];
        setMute();
    }
	
	// Update is called once per frame
	void Update () {
        setMute();
	}

    void setMute() {
        goodMusic.mute = Swapper.getUpperScreenCanCatch();
        badMusic.mute = !Swapper.getUpperScreenCanCatch();

    }

}
