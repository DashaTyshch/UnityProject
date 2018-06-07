using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {
	protected override void onRabbitHit(HeroRabbit rabbit) {
		this.CollectedHide ();
		if (rabbit != null) {
			if (rabbit.isBigger) {
				rabbit.resize (1);
			} else {
				Animator animator = rabbit.GetComponent<Animator> ();
				animator.SetTrigger ("die");
			}
		}
	}
}
