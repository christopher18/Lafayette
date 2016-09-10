using UnityEngine;
using System.Collections;

//handles object's health
public class Health_Script : MonoBehaviour {
	//total health points
	public int health = 1;

	//tracks if player or enemy
	public bool isEnemy = false;

	//inflicts the damage
	public void Damage(int damageCount) {
		health -= damageCount;

		if (health <= 0) {
			//death
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		//a shot?
		Cannon_Script cannon = otherCollider.gameObject.GetComponent<Cannon_Script>();

		if (cannon !=null) {
			//avoid friendly fire
			if (cannon.isEnemyShot != isEnemy) {
				Damage (cannon.damage);

				//destroy the shot
				Destroy(cannon.gameObject); //targeting the object so the script isn't deleted
			}
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
