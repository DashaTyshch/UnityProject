using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {
	protected override void onRabbitHit(HeroRabbit rabbit) {
		this.CollectedHide ();
		if (rabbit != null) {
			rabbit.resize (2);
		}
	}
}
