using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	protected virtual void onRabbitHit(HeroRabbit rabbit) {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		//if (!this.hideAnimation) {
			HeroRabbit rabbit = collider.GetComponent<HeroRabbit> ();
			if (rabbit != null) {
				this.onRabbitHit (rabbit);
			}
		//}
	}

	public void CollectedHide() {
		Destroy (this.gameObject);
	}
}
