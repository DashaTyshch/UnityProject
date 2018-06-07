using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;
	int coins = 0;

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
		//rabbit.animator.SetBool ("die", true);
		rabbit.transform.position = this.startingPosition;
		//rabbit.animator.SetBool ("die", false);
	}

	public void addCoins(int n) {
		this.coins += n;
		print (coins);
	}
}
