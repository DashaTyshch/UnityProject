using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {
	public static bool isPaused = false;
	public GameObject Panel;

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isPaused)
				Resume ();
			else
				Pause ();
		}
	}
	public void Resume() {
		Panel.SetActive (false);
		Time.timeScale = 1f;
		isPaused = false;
	}
	public void Pause() {
		Panel.SetActive (true);
		Time.timeScale = 0f;
		isPaused = true;
	}
}
