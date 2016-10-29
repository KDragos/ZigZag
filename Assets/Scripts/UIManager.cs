using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour { 

	public static UIManager instance;

	public GameObject zigZagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}

	}

	// Use this for initialization
	void Start () {
		highScore1.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStart() {
		tapText.SetActive(false);
		zigZagPanel.GetComponent<Animator>().Play("panelUp");
	}

	public void GameOver() {
		score.text = PlayerPrefs.GetInt("Score").ToString();
		highScore2.text = PlayerPrefs.GetInt("HighScore").ToString();
		gameOverPanel.SetActive(true);
	}

	public void Reset ()
	{
		SceneManager.LoadScene("Level1");
	}

}
