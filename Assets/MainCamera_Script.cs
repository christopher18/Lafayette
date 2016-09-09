using UnityEngine;
using System.Collections;

public class MainCamera_Script : MonoBehaviour {

	Transform target;
	float distance;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
		distance = 2.5f;
	}

	void Update(){

		GetComponent<Camera>().transform.position = new Vector3(
			target.transform.position.x, 
				target.transform.position.y,
					target.transform.position.z - distance);

	}
}
