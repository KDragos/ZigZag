using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public GameObject particle;

	[SerializeField] // Causes the private variable to show up in the editor.
	private float speed;
	bool started;
	bool gameOver;
	Rigidbody rb;

	// Awake is called upon object creation.
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{	// Starts the game.
		if (!started) {
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;
				GameManager.instance.StartGame();
			}
		}  

		// Checks for game over.
		Debug.DrawRay(transform.position, Vector3.down, Color.red); // To see where the 
		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.velocity = new Vector3 (0, -(speed*3), 0);

			Camera.main.GetComponent<CameraFollow>().gameOver = true;
//			GetComponent<PlatformSpawner>().gameOver = true;
			GameManager.instance.GameOver();
		}

		// Player can change direction.
		if (Input.GetMouseButtonDown (0) && !gameOver) {
			SwitchDirection ();
		}

	}

	void SwitchDirection ()
	{
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3(speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3(0, 0, speed);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Diamond") {
			ScoreManager.instance.IncrementScore(25);
			GameObject particleSystem = (GameObject) Instantiate(particle, col.gameObject.transform.position, particle.transform.rotation);
			Destroy(col.gameObject);
			Destroy(particleSystem, 1f);
		}
	}
}
