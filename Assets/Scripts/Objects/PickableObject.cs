using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour {

    public bool isCatchable;
	public AudioClip clip;
	public int score;

	// Use this for initialization
	void Start () {
		clip = GetComponent<AudioSource> ().clip;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up);
	}

	public void PlaySound() {
		Debug.Log ("Playing " + clip);
		if (clip) {
			AudioSource.PlayClipAtPoint (clip, transform.position);
		}
	}
}
