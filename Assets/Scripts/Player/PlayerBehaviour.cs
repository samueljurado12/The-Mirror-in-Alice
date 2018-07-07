using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


	private Rigidbody2D rb;
	[Range (1, 2)]
	public int playerNumber;
	public float speed;
	public float jumpForce;
	public float jumpSpeed1;
	public float jumpSpeed2;
	public float gravityForce = 5;
	public float maxFallSpeed = 10;
	public float fallForce;
	public bool onGround;
	public Vector2 velocity;
	public PlayerState currentState;
	float horizontalDir = 0;
	public int airJumps;

	public float maxTime;
	float airTime;
	bool jumped = false;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		currentState = PlayerState.STAND;
		onGround = false;
		airTime = 0;
	}

	void FixedUpdate () {
		velocityUpdate ();
		rb.velocity = velocity;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Ground")) {
			velocity.y = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag ("Ground")) {
			onGround = true;
			airJumps = 2;
			airTime = maxTime;
			jumped = false;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.CompareTag ("Ground")) {
			onGround = false;
		}
	}

	void velocityUpdate () {
		switch (currentState) {
		case PlayerState.STAND:
			velocity.x = 0;
			jumpSpeed1 = jumpSpeed2;

			if (!onGround) {
				currentState = PlayerState.JUMPING;
				break;
			}
			if (Input.GetAxis ("Horizontal" + playerNumber) != 0) {
				currentState = PlayerState.WALKING;
			}

			if (Input.GetButtonDown ("Jump" + playerNumber)) {
				airJumps--;
				currentState = PlayerState.JUMPING;
				break;
			}
			break;

		case PlayerState.JUMPING:
			progresiveJump ();
			velocity.y -= gravityForce * Time.deltaTime;
			velocity.y = Mathf.Max (velocity.y, -maxFallSpeed);
			horizontalDir = Input.GetAxis ("Horizontal" + playerNumber);


			if (Input.GetAxis ("Vertical" + playerNumber) == -1) {
				velocity.y -= gravityForce * Time.deltaTime * fallForce;
			}
			if (horizontalDir == 0) {
				velocity.x = 0;
			} else {
				velocity.x = horizontalDir * speed;
			}

			if (onGround) {
				if (horizontalDir == 0) {
					currentState = PlayerState.STAND;
				} else {
					currentState = PlayerState.WALKING;
				}
			} else {
				if (jumped) {
					if (Input.GetButtonDown ("Jump" + playerNumber) && airJumps > 0) {
						/*velocity.y = Mathf.Min (jumpForce * secondJumpSpeed, jumpForce);
						secondAirTime -= 0.25f;
						if (secondJumpSpeed <= 1) {					//Progresive Jump
							secondJumpSpeed += 0.05f;
						}*/
						//rb.AddForce (Vector2.up, ForceMode2D.Impulse);
						/////velocity.y = secondJumpSpeed;
						airJumps--;
						airTime = maxTime;
						jumpSpeed1 = jumpSpeed2;
						currentState = PlayerState.DOUBLEJUMPING;
						break;
					}
				}
			}
			break;

		case PlayerState.DOUBLEJUMPING:
			progresiveJump ();
			velocity.y -= gravityForce * Time.deltaTime;
			velocity.y = Mathf.Max (velocity.y, -maxFallSpeed);
			horizontalDir = Input.GetAxis ("Horizontal" + playerNumber);
			if (Input.GetAxis ("Vertical" + playerNumber) == -1) {
				velocity.y -= gravityForce * Time.deltaTime * fallForce;
			}
			if (horizontalDir == 0) {
				velocity.x = 0;
			} else {
				velocity.x = horizontalDir * speed;
			}
			if (onGround) {
				if (horizontalDir == 0) {
					currentState = PlayerState.STAND;
				} else {
					currentState = PlayerState.WALKING;
				}
			}

			break;

		case PlayerState.WALKING:
			jumpSpeed1 = jumpSpeed2;
			horizontalDir = Input.GetAxis ("Horizontal" + playerNumber);

			if (horizontalDir == 0) {
				currentState = PlayerState.STAND;
			}
			if (Input.GetButtonDown ("Jump" + playerNumber)) {
				airJumps--;
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

	void progresiveJump(){
		if (Input.GetButton ("Jump" + playerNumber) && airTime > 0) {
			velocity.y = Mathf.Min (jumpForce * jumpSpeed1, jumpForce);
			airTime -= 0.25f;
			if (jumpSpeed1 <= 1) {
				jumpSpeed1 += 0.05f;
			}
			jumped = true;
		}
	}


	public enum PlayerState {
		STAND,
		JUMPING,
		DOUBLEJUMPING,
		WALKING}

	;
}
