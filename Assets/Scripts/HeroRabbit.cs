using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour {
	public float speed = 3;
	float value = 0;
	Rigidbody2D myBody = null;

	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;


	void Awake() {
		value = Input.GetAxis("Horizontal");
	}

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		LevelController.current.setStartingPosition (transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		value = Input.GetAxis("Horizontal");
		Animator animator = GetComponent<Animator> ();

		if (Mathf.Abs (value) > 0) {
			animator.SetBool ("run", true);

			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		} else {
			animator.SetBool ("run", false);
		}
		if (this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
		}
	

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		if (value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}

		Vector3 from =  transform.position + Vector3.up*0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		RaycastHit2D hit = Physics2D.Linecast (from, to, layer_id);
		if (hit) {
			isGrounded = true;
			if (hit.transform != null && hit.transform.GetComponent<MovingPlatform> () != null) {
				SetNewParent (this.transform, hit.transform);
			}
		} else {
			isGrounded = false;
			SetNewParent (this.transform, hit.transform);
		}

		Debug.DrawLine (from, to, Color.red);

		if(Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true;
		}
		if (this.JumpActive) {
			if (Input.GetButton ("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}
	}

	static void SetNewParent(Transform obj, Transform new_parent) {
		if (obj.transform.parent != new_parent) {
			Vector3 pos = obj.transform.position;
			obj.transform.parent = new_parent;
			obj.transform.position = pos;
		}
	}
}
