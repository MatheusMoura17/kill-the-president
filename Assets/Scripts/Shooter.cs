using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public Transform spawnPoint;
	public float fireRate = 2;
	private float fireTimer=0;
	private bool canShoot;
	public int damage;

	private BulletSpawner spawner;

	void Start(){
		spawner = BulletSpawner.instance;
	}

	void Update () {
		if (!canShoot) {
			fireTimer += Time.deltaTime;
			canShoot = fireTimer >= fireRate;
		}
	}

	void ResetShoot(){
		fireTimer = 0;
		canShoot = false;
	}

	public void ShootAt(Transform targetEnemy){
		if (canShoot) {
			GameObject gm=spawner.SpawnBullet (spawnPoint.position, spawnPoint.rotation);
			Bullet bullet = gm.GetComponent<Bullet> ();
			bullet.damage = damage;
			bullet.targetTransform=targetEnemy;
			ResetShoot ();
		}
	}
}
