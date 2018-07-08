using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyService : MonoBehaviour {

	public static float difficulty = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		difficulty += (1 / Mathf.Pow(difficulty, 2))/5 * Time.deltaTime;
		Debug.Log (difficulty);

	}
}
