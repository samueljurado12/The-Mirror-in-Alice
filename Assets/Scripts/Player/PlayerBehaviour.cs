using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    private Rigidbody2D rb;
    [Range(1,2)]
    public int playerNumber;
    public float speed;
    public float jumpForce;
    public float gravityForce = 5;
    public float maxFallSpeed = 10;
    public float fallForce;
    public bool onGround;
    public Vector2 velocity;
    public PlayerState currentState;
    float horizontalDir = 0;
    //float lastDir = 0;
    public int airJumps = 1;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        currentState = PlayerState.STAND;
        onGround = false;
    }

    void FixedUpdate() {
        velocityUpdate();
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            velocity.y = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            onGround = false;
        }
    }

    void velocityUpdate() {
        switch (currentState) {
            case PlayerState.STAND:
                velocity.x = 0;
                airJumps = 1;
                if (!onGround) {
                    currentState = PlayerState.JUMPING;
                    break;
                }
                if (Input.GetAxis("Horizontal" + playerNumber) != 0) {
                    currentState = PlayerState.WALKING;
                }

                //         if (Input.GetKey (KeyCode.A)) {
                //         	horizontalDir = -1;
                //	currentState = PlayerState.WALKING;
                //} else if (Input.GetKey (KeyCode.D)) {
                //	horizontalDir = 1;
                //	currentState = PlayerState.WALKING;
                //}

                if (Input.GetButton("Jump"+playerNumber)) {
                    velocity.y = jumpForce;
                    currentState = PlayerState.JUMPING;
                    break;
                }
                break;

            case PlayerState.JUMPING:
                velocity.y -= gravityForce * Time.deltaTime;
                Mathf.Max(velocity.y, -maxFallSpeed);
                horizontalDir = Input.GetAxis("Horizontal" + playerNumber);

                //if (Input.GetKey(KeyCode.A)) {
                //    horizontalDir = -1;
                //    //lastDir = horizontalDir;
                //    //speedReduction = 0.95f;
                //} else if (Input.GetKey(KeyCode.D)) {
                //    horizontalDir = 1;
                //    //lastDir = horizontalDir;
                //    //speedReduction = 0.95f;
                //} else {
                //    horizontalDir = 0;
                //}

                if (Input.GetKey(KeyCode.S)) {
                    velocity.y -= gravityForce * Time.deltaTime * fallForce;
                }
                if (horizontalDir == 0) {
                    velocity.x = 0;//lastDir * speed * speedReduction;
                                   //peedReduction -= 0.01f;
                } else {
                    velocity.x = horizontalDir * speed;
                }

                if (onGround) {
                    //speedReduction = 0.95f;
                    //lastDir = 0;
                    if (horizontalDir == 0) {
                        currentState = PlayerState.STAND;
                    } else {
                        currentState = PlayerState.WALKING;
                    }
                } else {
                    if (Input.GetButton("Jump"+playerNumber) && airJumps > 0) {
                        Debug.Log(airJumps);
                        velocity.y = jumpForce;
                        airJumps--;
                        break;
                    }
                }
                break;

            case PlayerState.WALKING:
                airJumps = 1;
                horizontalDir = Input.GetAxis("Horizontal" + playerNumber);

                if (horizontalDir == 0) {
                    currentState = PlayerState.STAND;
                }
                if (Input.GetButton("Jump"+playerNumber)) {
                    velocity.y = jumpForce;
                    currentState = PlayerState.JUMPING;
                    break;
                }
                velocity.x = speed * horizontalDir;
                if (!onGround) {
                    currentState = PlayerState.JUMPING;
                }
                break;
        }
    }


    public enum PlayerState { STAND, JUMPING, WALKING };

}
