using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public enum Stats
	{
		SEARCHING,
		SHOOTING,
		KILLED
	}

	public Transform cannonTransform;
	public Transform targetEnemy;
	public Shooter shooter;
	public float activationDistance=5;
	private Stats currentStat;

	void Update () {
		switch (currentStat) {
			case Stats.SEARCHING:
				Search ();
				break;
			case Stats.SHOOTING:
				Shoot ();
				break;
			case Stats.KILLED:
				Kill ();
				break;
		}
	}

	private void Search(){
		cannonTransform.Rotate (0, 25 * Time.deltaTime, 0);

		if (Vector3.Distance (transform.position, targetEnemy.position) <= activationDistance)
			currentStat = Stats.SHOOTING;
	}

	private void Shoot(){
		Vector3 position = targetEnemy.position;
		position.y = cannonTransform.position.y;
		cannonTransform.LookAt (position);
		shooter.ShootAt (targetEnemy);
		
		if (Vector3.Distance (transform.position, targetEnemy.position) > activationDistance)
			currentStat = Stats.SEARCHING;
	}

	private void Kill(){

	}
}
