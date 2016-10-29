using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public int score;
	public int highScore;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt("Score", score);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementScore() {
		score += 1;
	}

	public void IncrementScore(int points) {
		score += points;
	}

	public void StartScore() {
		InvokeRepeating("IncrementScore", 0.1f, 0.5f);
	}

	public void StopScore() {
		CancelInvoke("IncrementScore");
		PlayerPrefs.SetInt("Score", score);
		updateHighScore();
	}

	public void updateHighScore ()
	{
		if (PlayerPrefs.HasKey("HighScore")) {
			if (score > PlayerPrefs.GetInt("HighScore")) {
				PlayerPrefs.SetInt("HighScore", score);
			}
		} else {
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
}
