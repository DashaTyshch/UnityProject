using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public Vector3 MoveBy = Vector3.right;
	[Range(0,10)]
	public float time_to_wait = 2f;
	public float speed = 12f;

	Vector3 pointA;
	Vector3 pointB;
	bool going_to_a = false;

	float _time_to_wait;
	bool waiting = false;

	Vector3 moveVector;

	// Use this for initialization
	void Start () {
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;

		this.moveVector = (this.pointB - this.pointA) * 0.001f * speed;
		this._time_to_wait = time_to_wait;


	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		Vector3 my_pos = this.transform.position;
		Vector3 target;

		if (going_to_a) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}

		Vector3 destination = this.transform.position;

		if (!waiting) {
			destination = my_pos + moveVector;
			destination.z = 0;

			if (isArrived (my_pos, target)) {
				going_to_a = !going_to_a;
				moveVector *= -1;
				waiting = true;
			}
		} 
		else {
			_time_to_wait -= Time.fixedDeltaTime;
			if (_time_to_wait <= 0) {
				waiting = false;
				_time_to_wait = time_to_wait;
			}
		}

		this.transform.position = destination;
	}

	//Чи доїхала платформа?
	bool isArrived(Vector3 pos, Vector3 target) {
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance (pos, target) < 0.02f;
	}
}
