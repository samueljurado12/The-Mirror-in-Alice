using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	private Rigidbody2D rb;

	[Range (1, 2)]
	public int playerNumber;

	public float speed;
	public float jumpForce;
	public float jumpSpeed;
	public float jumpRate;
	public float gravityForce = 5;
	public float maxFallSpeed = 10;
	public float fallForce;

	public int airJumps;
	public float maxTime;

	public bool onGround;
	public Vector2 velocity;
	public PlayerState currentState;

	float horizontalDir = 0;
	float verticalDir = 0;
	float airTime;
	bool jumped = false;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		currentState = PlayerState.STAND;
		onGround = false;
		airTime = 0;
		if (playerNumber == 2) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
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
			jumpSpeed = jumpRate;

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
			verticalDir = Input.GetAxis ("Vertical" + playerNumber);

			if (verticalDir == -1) {
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
						airJumps--;
						airTime = maxTime;
						jumpSpeed = jumpRate;
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
			verticalDir = Input.GetAxis ("Vertical" + playerNumber);

			if (verticalDir == -1) {
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
			jumpSpeed = jumpRate;
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
			velocity.y = Mathf.Min (jumpForce * jumpSpeed, jumpForce);
			airTime -= 0.25f;
			if (jumpSpeed <= 1) {
				jumpSpeed += 0.05f;
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
