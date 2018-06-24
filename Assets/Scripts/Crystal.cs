using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {
	public CrystalType type;
	public enum CrystalType
	{
		Blue, Green, Red
	}

	protected override void onRabbitHit(HeroRabbit rabbit) {
		LevelController.current.addCrystal (this.type);
		this.CollectedHide ();
	}
}
