﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {
	protected override void onRabbitHit(HeroRabbit rabbit) {
		this.CollectedHide ();
	}
}
