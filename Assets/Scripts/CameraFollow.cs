using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject ball;
	Vector3 offset;
	public float lerpRate;
	public bool gameOver;

	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameOver) {
			Follow();
		}
	}

	void Follow() {
		Vector3 position = transform.position; // stores the original.
		Vector3 targetPosition = (ball.transform.position - offset); 
		position = Vector3.Lerp(position, targetPosition, lerpRate * Time.deltaTime);
		transform.position = position;
	}
}
