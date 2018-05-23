using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	void Awake() {
		current = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setStartingPosition(Vector3 pos) {
		this.startingPosition = pos;
	}

	public void onRabbitDeath(HeroRabbit rabbit) {
		rabbit.transform.position = this.startingPosition;
		print ("Triggered");
	}
}
