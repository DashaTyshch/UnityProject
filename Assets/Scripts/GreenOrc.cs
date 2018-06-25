﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GreenOrc : MonoBehaviour {
	public float speed = 2f;
	public Vector3 MoveBy = Vector3.right;

	Rigidbody2D myBody = null;
	Animator animator = null;
	SpriteRenderer sr = null;

	public float value = 0;
	Vector3 pointA;
	public Vector3 pointB;

	private float runSpeed = 0;
	private float walkSpeed = 0;

	public enum Mode {
		GoToA,
		GoToB,
		Attack,
		Die
	}

	public Mode mode = Mode.GoToB;

	void Awake() {
		value = this.GetDirection ();
		animator = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;
		runSpeed = speed + 1f;
		walkSpeed = speed;
	}

	void FixedUpdate () {
		Vector3 my_pos = this.transform.position;

		float rabbit_pos_x = HeroRabbit.lastRabbit.transform.position.x;
		float rabbit_pos_y = HeroRabbit.lastRabbit.transform.position.y;
		if (rabbit_pos_x >= Mathf.Min (pointA.x, pointB.x) && rabbit_pos_x <= Mathf.Max (pointA.x, pointB.x)
			&& Math.Abs(rabbit_pos_y-this.transform.position.y)<0.4) {
			mode = Mode.Attack;
		} else if (mode == Mode.Attack) {
			mode = Mode.GoToA;
		}

		if (mode == Mode.GoToA) {
			speed = walkSpeed;
			if (isArrived (pointA))
				mode = Mode.GoToB;
		} else if (mode == Mode.GoToB) {
			speed = walkSpeed;
			if (isArrived (pointB))
				mode = Mode.GoToA;
		} else if (mode == Mode.Attack) {
			speed = runSpeed;
			animator.SetBool ("walk", false);
			animator.SetBool ("run", true);
		}

		value = this.GetDirection ();
		Vector2 vel = myBody.velocity;
		if (Mathf.Abs (value) > 0) {
			animator.SetBool ("walk", true);
			vel.x = value * speed;
			myBody.velocity = vel;

			if (value < 0)
				sr.flipX = false;
			else
				sr.flipX = true;
		}
			
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name != "HeroRabbit")
			return;
		Collider2D collider = collision.collider;

		Vector3 contact = collision.contacts[0].point;
		Vector3 center = collider.bounds.center;
		if (Math.Abs (contact.y - center.y) > 0.4) {
			value = 0;
			speed = 0f;
			animator.SetTrigger ("death");
		} else {
			animator.SetTrigger ("attack");
			Animator animatorR = HeroRabbit.lastRabbit.GetComponent<Animator> ();
			animatorR.SetTrigger ("die");
		}
	}

	float GetDirection () {
		Vector3 my_pos = this.transform.position;

		if (mode == Mode.Attack) {
			if (my_pos.x < HeroRabbit.lastRabbit.transform.position.x)
				return 1;
			else
				return -1;
		} else if (mode == Mode.GoToA) {
			if (my_pos.x < pointA.x)
				return 1;
			else
				return -1;
		} else if (mode == Mode.GoToB) {
			if (my_pos.x < pointB.x)
				return 1;
			else
				return -1;
		}

		return 0;
	}

	void Die() {
		Destroy (this.gameObject);
	}

	bool isArrived(Vector3 target) {
		return Mathf.Abs (this.transform.position.x - target.x) < 0.02f;
	}
}
