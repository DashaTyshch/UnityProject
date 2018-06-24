using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	int lifes = 3;
	public Image[] lifesImg = new Image[3];
	public Sprite lostLife = null;

	int coins = 0;
	public Text coinsLabel = null;

	int fruit;
	int doneFruit = 0;
	public Text fruitLabel = null;

	public Image crystalRed = null;
	public Image crystalGreen = null;
	public Image crystalBlue = null;
	public Sprite Red = null;
	public Sprite Green = null;
	public Sprite Blue = null;

	void Awake() {
		current = this;
		fruit = FindObjectsOfType<Fruit>().Length;
	}
	// Use this for initialization
	void Start () {
		if(coinsLabel!=null)
			coinsLabel.text = "0000";
		if(fruitLabel!=null)
			fruitLabel.text = "0/" + fruit;
	}

	public void setStartingPosition(Vector3 pos) {
		this.startingPosition = pos;
	}

	public void onRabbitDeath(HeroRabbit rabbit) {
		if (SceneManager.GetActiveScene ().name != "ChooseLevel") {
			if (lifes == 0)
				SceneManager.LoadScene ("ChooseLevel");
			else {
				lifes--;
				lifesImg [lifes].sprite = lostLife;
				rabbit.transform.position = this.startingPosition;
			}
		} else {
			rabbit.transform.position = this.startingPosition;
		}
	}

	public void addCoins() {
		coins++;
		string con = coins.ToString ();
		while (con.Length < 4)
			con = "0" + con;
		coinsLabel.text = con;
	}
	public void addFruit(int n) {
		doneFruit += n;
		fruitLabel.text = doneFruit+"/"+fruit;
	}
	public void addCrystal(Crystal.CrystalType type) {
		switch(type) {
		case Crystal.CrystalType.Blue:
			crystalBlue.sprite = Blue;
			break;
		case Crystal.CrystalType.Red:
			crystalRed.sprite = Red;
			break;
		case Crystal.CrystalType.Green:
			crystalGreen.sprite = Green;
			break;
		default:
			break;
		}
	}
}
