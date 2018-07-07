using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{

    public bool isCatcher;
    public bool isPlayerOne;
    ScoreService scoreService;

    // Use this for initialization
    void Start()
    {
        scoreService = ScoreService.getInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            PickableObject target = collision.gameObject.GetComponent<PickableObject>();

            if (target.isCatchable == isCatcher)
            {
                // Sumar puntuaciones
                if (isPlayerOne)
                {
                    scoreService.increasePlayer1Score(target.score);
                }
                else
                {
                    scoreService.increasePlayer2Score(target.score);
                }

            }
            else
            {
                // Restar puntuación y cambiar modo
                if (isPlayerOne)
                {
                    scoreService.decreasePlayer1Score(target.score);
                }
                else
                {
                    scoreService.decreasePlayer2Score(target.score);
                }

                isCatcher = !isCatcher;
            }

            Destroy(collision.gameObject);
        }
    }
}
