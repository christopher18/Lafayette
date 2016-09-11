using UnityEngine;
using System.Collections;

public class Cannon_Script : MonoBehaviour {

	//shot damage
	public int damage = 1;

	//tracks whose bullet this is
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 6); //will destroy after 15 seconds
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
