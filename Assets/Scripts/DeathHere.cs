using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		HeroRabbit rabbit = collider.GetComponent<HeroRabbit> ();
		if (rabbit != null) {
			LevelController.current.onRabbitDeath (rabbit);
		}
	}
}
