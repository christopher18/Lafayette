using UnityEngine;
using System.Collections;

public class Treasure_Spawn : MonoBehaviour {

	public Transform treasurePrefab;
	public float spawnRate = 30;
	public float cannonPower = 20;

	private float spawnCooldown;

	// Use this for initialization
	void Start () {
		spawnCooldown = 0f;
	}

	// Update is called once per frame
	void Update () {
		if (spawnCooldown > 0) {
			spawnCooldown -= Time.deltaTime;
		} else if (spawnCooldown <= 0) {
			var shotTransform = Instantiate (treasurePrefab) as Transform;

			//assign position
			shotTransform.position = new Vector3 (0, 0, 0);

			spawnCooldown = spawnRate;
		}
	}
	

}
