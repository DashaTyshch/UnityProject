using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable: MonoBehaviour {

	protected virtual void onRabbitHit(HeroRabbit rabbit) {}

	void OnTriggerEnter2D(Collider2D collider) {
		HeroRabbit rabbit = collider.GetComponent<HeroRabbit> ();
		if (rabbit != null) {
			this.onRabbitHit (rabbit);
		}
	}

	public void CollectedHide() {
		Destroy (this.gameObject);
	}
}