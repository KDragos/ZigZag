using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamond;
	public bool gameOver;
	Vector3 lastPosition;
	float platformSize; 

	// Use this for initialization
	void Start ()
	{
		gameOver = false;
		lastPosition = platform.transform.position;
		platformSize = platform.transform.localScale.x;

		for (int i = 0; i < 20; i++) {
			SpawnPlatforms();
		}

	}

	public void StartSpawningPlatforms() {
		InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (GameManager.instance.gameOver == true) {
			CancelInvoke("SpawnPlatforms");
		}
	}

	void SpawnPlatforms ()
	{
		int rand = Random.Range (0, 7);
		if (rand < 3) {
			SpawnX ();
		} else {
			SpawnZ();
		}
		
	}

	// Spawns platform in the x direction.
	void SpawnX ()
	{
		Vector3 pos = lastPosition;
		pos.x += platformSize;
		lastPosition = pos;
		Instantiate (platform, pos, Quaternion.identity);

		SpawnDiamond(pos);
	}

	// Spanws platform in the z direction.
	void SpawnZ() {
		Vector3 pos = lastPosition;
		pos.z += platformSize;
		lastPosition = pos;
		Instantiate(platform, pos, Quaternion.identity);

		SpawnDiamond(pos);
	}

	void SpawnDiamond(Vector3 pos) {
		
		int rand = Random.Range (0, 4);
		if (rand < 1) {
			Instantiate (diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation); 
		}
	}
}
