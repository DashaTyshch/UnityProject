using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour {
	public string name;

	void OnTriggerEnter2D(Collider2D collider){
		HeroRabbit rabbit = collider.GetComponent<HeroRabbit> ();
		if (rabbit != null) {
			SceneManager.LoadScene (name);
		}
	}
}
