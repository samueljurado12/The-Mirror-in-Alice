using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    LifeService lifeService;
    ScoreService scoreService;

    [SerializeField] Text p1Score, p2Score;

	// Use this for initialization
	void Start () {
        lifeService = LifeService.getInstance();
        scoreService = ScoreService.getInstance();

	}
	
	// Update is called once per frame
	void Update () {
        p1Score.text = scoreService.player1Score.ToString();
        p1Score.text = scoreService.player2Score.ToString();

        updatePlayer1Life();
        updatePlayer2Life();
	}

    private void updatePlayer1Life()
    {
        int life = lifeService.player1Life;
        //TODO: modify life sprites
    }

    private void updatePlayer2Life()
    {
        int life = lifeService.player2Life;
        //TODO: modify life sprites
    }
}
