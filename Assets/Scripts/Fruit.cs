using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {
	protected override void onRabbitHit(HeroRabbit rabbit) {
		LevelController.current.addFruit (1);
		this.CollectedHide ();
	}
}
