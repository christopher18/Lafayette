using UnityEngine;
using System.Collections;

//fire projectiles
public class Weapon_Script : MonoBehaviour {

	//prefab of projectile
	public Transform cannonPrefab;

	//cooldown for shooting
	public float shootingRate = 2f;
	public float cannonPower = 20;

	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	//create new projectile if possible
	public void Attack(bool isEnemy, Transform shootingShip, int shotCount) {
		if (CanAttack) {
			shootCooldown = shootingRate;
			int starboard = 1;

			for (int i = 0; i < shotCount; i++) {
				//create new shot
				var shotTransform = Instantiate (cannonPrefab) as Transform;

				//assign position
				shotTransform.position = transform.position + 0.3f * ((int) (i/2) * shootingShip.up) - (shotCount/2) * (0.2f) * shootingShip.up;

				Cannon_Script cannon = shotTransform.gameObject.GetComponent<Cannon_Script> ();

				if (cannon != null) {
					cannon.isEnemyShot = isEnemy;
				}

				starboard *= -1;

				Vector2 inertiaVelocity = new Vector2 (shootingShip.GetComponent<Rigidbody2D> ().velocity.x, shootingShip.GetComponent<Rigidbody2D> ().velocity.y);
				shotTransform.gameObject.GetComponent<Rigidbody2D> ().velocity = (Vector2)(shootingShip.right * cannonPower * starboard) + (inertiaVelocity);
			}

		}
	}

	//is the weapon off cooldown
	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}
