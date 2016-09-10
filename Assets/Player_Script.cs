using UnityEngine;
using System.Collections;


public class Player_Script : MonoBehaviour {

	//base speed of the ship
	const int SPEED = 2;
	const int TURNSPEED = 100;

	//angle of ship, and to mouse
	float shipAngle;
	float mouseAngle;

	float angleToTurn;

	// Use this for initialization
	void Start () {
		
	}
		
	void FixedUpdate () {
		

		Vector3 mousePlace = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 2.5f));
		Vector2 diff2D = new Vector2 (mousePlace.x, mousePlace.y);

		//angle from center of screen to mouse, in degrees
		mouseAngle = Mathf.Atan(diff2D.y / diff2D.x) * (180 / Mathf.PI);


		if (diff2D.y > 0 && diff2D.x < 0) {
			mouseAngle = 90 + mouseAngle;
		} else if (diff2D.y < 0 && diff2D.x < 0) {
			mouseAngle = 90 + mouseAngle;
		} else if (diff2D.y < 0 && diff2D.x > 0) {
			mouseAngle = 270 + mouseAngle;
		} else {
			mouseAngle += 270;
		}
			
		Debug.Log (mouseAngle);

		shipAngle = transform.eulerAngles.z;
		//Debug.Log (shipAngle);

		//clean and efficient turns
		if (shipAngle > mouseAngle) {
			angleToTurn = shipAngle - mouseAngle;
			if (angleToTurn > 180) {
				GetComponent<Rigidbody2D> ().angularVelocity = TURNSPEED;
			} else if (angleToTurn < 2) {
				GetComponent<Rigidbody2D> ().angularVelocity = 0;
			} else {
				GetComponent<Rigidbody2D> ().angularVelocity = -TURNSPEED;
			}
		} else {
			angleToTurn = mouseAngle - shipAngle;
			if (angleToTurn > 180) {
				GetComponent<Rigidbody2D> ().angularVelocity = -TURNSPEED;
			} else if (angleToTurn < 2) {
				GetComponent<Rigidbody2D> ().angularVelocity = 0;
			} else {
				GetComponent<Rigidbody2D> ().angularVelocity = TURNSPEED;
			}
		}

//		//move in direction the ship is facing
//		Vector2 curFace = new Vector2 (1, Mathf.Tan(transform.eulerAngles.z));
//		curFace.Normalize ();
//		//Debug.Log (curFace);
//		GetComponent<Rigidbody2D> ().velocity = new Vector2 (1,0) * SPEED;
	}

}

