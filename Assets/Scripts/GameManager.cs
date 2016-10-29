using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		gameOver = false; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		gameOver = false;
		UIManager.instance.GameStart();
		ScoreManager.instance.StartScore(); // I'll want to change the rate of invoking.
		GameObject.Find("PlatformSpawnerA").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
		GameObject.Find("PlatformSpawnerB").GetComponent<PlatformSpawner>().StartSpawningPlatforms();

	}

	public void GameOver() {
		gameOver = true;
		UIManager.instance.GameOver();
		ScoreManager.instance.StopScore(); // See note above. 
		Debug.Log("Our score: " + PlayerPrefs.GetInt("Score"));
	}
}
