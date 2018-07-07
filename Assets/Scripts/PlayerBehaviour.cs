using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	private Rigidbody2D rb;

	public float speed;
	public float jumpForce;
	public float gravityForce = 5;
	public float maxFallSpeed = 10;
	public bool onGround;
	public Vector2 velocity;
	public PlayerState currentState;
	float horizontalDir = 0;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		currentState = PlayerState.STAND;
		onGround = false;
	}

	void FixedUpdate () {
		velocityUpdate ();
		rb.velocity = velocity;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ground")) {
			velocity.y = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Ground")) {
			onGround = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.CompareTag ("Ground")) {
			onGround = false;
		}
	}

	void velocityUpdate(){
		switch (currentState) {
		case PlayerState.STAND:
			if (!onGround) {
				currentState = PlayerState.JUMPING;
				break;
			}
			if (Input.GetKey (KeyCode.A)) {
				horizontalDir = -1;
				currentState = PlayerState.WALKING;
			} else if (Input.GetKey (KeyCode.D)) {
				horizontalDir = 1;
				currentState = PlayerState.WALKING;
			}
			if (Input.GetKey (KeyCode.Space)) {
				velocity.y = jumpForce;
				currentState = PlayerState.JUMPING;
				break;
			}
			break;

		case PlayerState.JUMPING:
			velocity.y -= gravityForce * Time.deltaTime;
			Mathf.Max (velocity.y, -maxFallSpeed);
			if (onGround) {
				currentState = PlayerState.STAND;
			}
			break;

		case PlayerState.WALKING:
			if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
				horizontalDir = 0;
			}
			velocity.x = speed * horizontalDir;
			currentState = PlayerState.STAND;
			break;
		}
	}


	public enum PlayerState {STAND, JUMPING, WALKING};
		
}
