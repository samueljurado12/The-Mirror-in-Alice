using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService
{
    public int player1Score = 0;
    public int player2Score = 0;

    static ScoreService instance;

    internal static ScoreService getInstance() {
        if (instance == null) {
            instance = new ScoreService();
        }
        return instance;
    }

    internal void increasePlayer1Score(int score) {
        player1Score += score;
    }

    internal void increasePlayer2Score(int score) {
        player2Score += score;
    }

    internal void decreasePlayer1Score(int score) {
        player1Score -= score;
        if (player1Score < 0) player1Score = 0;
    }

    internal void decreasePlayer2Score(int score) {
        player2Score -= score;
        if (player2Score < 0) player2Score = 0;
    }

    public int getTotalScore() {
        return player1Score + player2Score;
    }
}
