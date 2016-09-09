using UnityEngine;
using System.Collections;


public class Player_Script : MonoBehaviour {

	//base speed of the ship
	const int SPEED = 20;
	const int TURNSPEED = 100;

	//locations of mouse and center of screen (ship)
	Vector3 mouseLocation;
	float mouseX;
	float mouseY;
	float shipX;
	float shipY;

	//angle of ship, and to mouse
	float shipAngle;
	float mouseAngle;

	float angleToTurn;

	// Use this for initialization
	void Start () {
		
	}
		
	void FixedUpdate () {

		//define location variables
//		mouseLocation = Input.mousePosition;
//		mouseX = mouseLocation.x;
//		mouseY = mouseLocation.y;
//		shipX = transform.position.x;
//		shipY = transform.position.x;

		Vector3 mousePlace = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 2.5f));

		Vector2 diff2D = new Vector2 (mousePlace.x, mousePlace.y);

		//angle from center of screen to mouse, in degrees
		mouseAngle = Mathf.Atan(diff2D.y / diff2D.x) * (180 / Mathf.PI);


		if (diff2D.y > 0 && diff2D.x < 0) {
			mouseAngle = 180 + mouseAngle;
		} else if (diff2D.y < 0 && diff2D.x < 0) {
			mouseAngle = 180 + mouseAngle;
		} else if (diff2D.y < 0 && diff2D.x > 0) {
			mouseAngle = 360 + mouseAngle;
		}
			
		//Debug.Log (mouseAngle);

		shipAngle = transform.eulerAngles.z - 90;
		//Debug.Log (shipAngle);

		// angle that the ship needs to turn
		angleToTurn = mouseAngle - shipAngle + 180;
		Debug.Log (angleToTurn);

		if (angleToTurn > 180) {
			GetComponent<Rigidbody2D> ().angularVelocity = -TURNSPEED;
		} else if (angleToTurn <= 180 && angleToTurn > 5) {
			GetComponent<Rigidbody2D> ().angularVelocity = TURNSPEED;
		} else{
			GetComponent<Rigidbody2D> ().angularVelocity = 0;
		}
		 
	}

}

