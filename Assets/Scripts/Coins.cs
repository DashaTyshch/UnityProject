using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {
	protected override void onRabbitHit(HeroRabbit rabbit) {
		LevelController.current.addCoins ();
		this.CollectedHide ();
	}
}
