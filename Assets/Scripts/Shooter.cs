using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject shootPrefab;
	public Transform spawnPoint;
	public float fireRate = 2;
	private float fireTimer=0;
	private bool canShoot;

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

	public void Shoot(){
		if (canShoot) {
			Instantiate (shootPrefab, spawnPoint.position, spawnPoint.rotation);
			ResetShoot ();
		}
	}
}
