using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable {

	public float speed;
	public float direction;
	public float lifeDuration;

	// Use this for initialization
	void Start() {
		StartCoroutine (DestroyLater ());
		GetComponent<SpriteRenderer> ().flipX = direction == 1;
	}
	// Update is called once per frame
	void FixedUpdate ()  {
		this.transform.position += new Vector3(speed*direction,0,0);
	}

	IEnumerator DestroyLater() {
		yield return new WaitForSeconds (lifeDuration);
		Destroy(this.gameObject);
	}

	protected override void onRabbitHit(HeroRabbit rabbit) {
		Animator animatorR = rabbit.GetComponent<Animator> ();
		animatorR.SetTrigger ("die");
		Destroy(this.gameObject);
	}
}
