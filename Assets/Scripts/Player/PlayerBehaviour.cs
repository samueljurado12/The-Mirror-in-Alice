using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {


	private Rigidbody2D rb;
	[Range (1, 2)]
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
	public int airJumps = 1;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		currentState = PlayerState.STAND;
		onGround = false;
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
			airJumps = 1;
			if (!onGround) {
				currentState = PlayerState.JUMPING;
				break;
			}
			if (Input.GetAxis ("Horizontal" + playerNumber) != 0) {
				currentState = PlayerState.WALKING;
			}

			if (Input.GetButtonDown ("Jump" + playerNumber)) {
				velocity.y = jumpForce;
				currentState = PlayerState.JUMPING;
				break;
			}
			break;

			if (Input.GetButtonDown ("Jump" + playerNumber)) {
				velocity.y = jumpForce;
				currentState = PlayerState.JUMPING;
				break;
			}
			break;

		case PlayerState.JUMPING:
			velocity.y -= gravityForce * Time.deltaTime;
			Mathf.Max (velocity.y, -maxFallSpeed);
			horizontalDir = Input.GetAxis ("Horizontal" + playerNumber);


			if (Input.GetAxis ("Vertical" + playerNumber) != 0) {
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
				if (Input.GetButtonDown ("Jump" + playerNumber) && airJumps > 0) {
					velocity.y = jumpForce;
					airJumps--;
					break;
				}
			}
			break;

		case PlayerState.WALKING:
			airJumps = 1;
			horizontalDir = Input.GetAxis ("Horizontal" + playerNumber);

			if (horizontalDir == 0) {
				currentState = PlayerState.STAND;
			}
			if (Input.GetButtonDown ("Jump" + playerNumber)) {
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


	public enum PlayerState {
		STAND,
		JUMPING,
		WALKING}

	;
}
