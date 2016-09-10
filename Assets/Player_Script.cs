using UnityEngine;
using System.Collections;


public class Player_Script : MonoBehaviour {

	//base speed of the ship
	public float speed;
	public float turnspeed;
	public int ammoCount;

	//angle of ship, and to mouse
	float shipAngle;
	float mouseAngle;

	float angleToTurn;

	// Use this for initialization
	void Start () {
		
	}

	//shooting
	void Update() {
		bool shoot = Input.GetButtonDown ("Fire1");

		if (shoot) {
			Weapon_Script weapon = GetComponent<Weapon_Script> ();
			if (weapon != null) {
				//false because player is no enemy
				weapon.Attack (false, this.transform, ammoCount);
			}
		}
	}

	void FixedUpdate() {
		//rotation target at mouse
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		//rotate slowly
		transform.rotation = Quaternion.RotateTowards (transform.rotation, rot, turnspeed);
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;

		//speed multiplier based on mouse distance
		float mouseX = Mathf.Abs(mousePosition.x - transform.position.x);
		float mouseY = Mathf.Abs(mousePosition.y - transform.position.y);
		float Xpercent = (mouseX / Camera.main.pixelWidth);
		float Ypercent = (mouseY / Camera.main.pixelHeight);
		float percentMagnitude = Mathf.Sqrt (Mathf.Pow (Xpercent, 2) + Mathf.Pow (Ypercent, 2)) * 50 + 0.3f; //normalize to 1 as max

		//set velocity at facing direction
		GetComponent<Rigidbody2D> ().velocity = gameObject.transform.up * speed * percentMagnitude;
		//Debug.Log (percentMagnitude);
	}
		
//	void FixedUpdate () {
//		
//
//		Vector3 mousePlace = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 2.5f));
//		Vector2 diff2D = new Vector2 (mousePlace.x, mousePlace.y);
//
//		//angle from center of screen to mouse, in degrees
//		mouseAngle = Mathf.Atan(diff2D.y / diff2D.x) * (180 / Mathf.PI);
//
//
//		if (diff2D.y > 0 && diff2D.x < 0) {
//			mouseAngle = 90 + mouseAngle;
//		} else if (diff2D.y < 0 && diff2D.x < 0) {
//			mouseAngle = 90 + mouseAngle;
//		} else if (diff2D.y < 0 && diff2D.x > 0) {
//			mouseAngle = 270 + mouseAngle;
//		} else {
//			mouseAngle += 270;
//		}
//			
//		Debug.Log (mouseAngle);
//
//		shipAngle = transform.eulerAngles.z;
//		//Debug.Log (shipAngle);
//
//		//clean and efficient turns
//		if (shipAngle > mouseAngle) {
//			angleToTurn = shipAngle - mouseAngle;
//			if (angleToTurn > 180) {
//				GetComponent<Rigidbody2D> ().angularVelocity = TURNSPEED;
//			} else if (angleToTurn < 2) {
//				GetComponent<Rigidbody2D> ().angularVelocity = 0;
//			} else {
//				GetComponent<Rigidbody2D> ().angularVelocity = -TURNSPEED;
//			}
//		} else {
//			angleToTurn = mouseAngle - shipAngle;
//			if (angleToTurn > 180) {
//				GetComponent<Rigidbody2D> ().angularVelocity = -TURNSPEED;
//			} else if (angleToTurn < 2) {
//				GetComponent<Rigidbody2D> ().angularVelocity = 0;
//			} else {
//				GetComponent<Rigidbody2D> ().angularVelocity = TURNSPEED;
//			}
//		}
//
////		//move in direction the ship is facing
////		Vector2 curFace = new Vector2 (1, Mathf.Tan(transform.eulerAngles.z));
////		curFace.Normalize ();
////		//Debug.Log (curFace);
////		GetComponent<Rigidbody2D> ().velocity = new Vector2 (1,0) * SPEED;
//	}

}

