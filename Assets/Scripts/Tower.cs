using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform cannonTransform;
	public Transform targetEnemy;
	public Shooter shooter;
	public float activationDistance=5;

	void Update () {
		if (Vector3.Distance (transform.position, targetEnemy.position) <= activationDistance) {
			Vector3 position = targetEnemy.position;
			position.y = cannonTransform.position.y;
			cannonTransform.LookAt (position);
			shooter.ShootAt (targetEnemy);
		}
	}
}
