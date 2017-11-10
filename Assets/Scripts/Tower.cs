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
	public Shooter shooter;
	public TargetLooker targetLooker;
	public float activationDistance=5;
	private Stats currentStat;
	public Damagable damagable;

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

	public void Enable(){
		damagable.Reset ();
	}

	private void Search(){
		cannonTransform.Rotate (0, 25 * Time.deltaTime, 0);
		if (!targetLooker.target)
			return;
		if (Vector3.Distance (transform.position, targetLooker.target.transform.position) <= activationDistance)
			currentStat = Stats.SHOOTING;
	}

	private void Shoot(){
		if (!targetLooker.target) {
			currentStat = Stats.SEARCHING;
			return;
		}
		Vector3 position = targetLooker.target.transform.position;
		position.y = cannonTransform.position.y;
		cannonTransform.LookAt (position);
		shooter.ShootAt (targetLooker.target.transform);
		
		if (Vector3.Distance (transform.position, targetLooker.transform.position) > activationDistance)
			currentStat = Stats.SEARCHING;
	}

	private void Kill(){

	}
}
