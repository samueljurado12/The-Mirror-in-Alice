using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(MusicFader.fadeIn(GetComponent<AudioSource>(), 2f, 1f));
    }

}
