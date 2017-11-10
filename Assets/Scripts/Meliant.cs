using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Meliant : MonoBehaviour {

	public enum Stats
	{
		MOVING,
		ATTACKING
	}

	public Animator animator;
	public TargetLooker targetLooker;
	public NavMeshAgent agent;
	public float range=3;
	private bool attacking;
	private Stats currentStat;
	public Shooter shooter;
	public Damagable damagable;
	
	// Update is called once per frame
	void Update () {
		switch(currentStat){
		case Stats.MOVING:
			Move();
			break;
		case Stats.ATTACKING:
			Attack();
			break;
		}
	}

	public void Reset(){
		currentStat = Stats.MOVING;
		shooter.ResetShoot ();
		damagable.Reset ();
	}

	public void Enable(){
		Reset ();
	}

	private void Move(){
		if (targetLooker.target){
			agent.destination = targetLooker.target.transform.position;
			if (agent.remainingDistance <= range) {
				animator.SetBool ("attacking", true);
				currentStat = Stats.ATTACKING;
			}
		}
	}

	private void Attack(){
		if (targetLooker.target && targetLooker.target.activeSelf){
			agent.destination = targetLooker.target.transform.position;
			shooter.ShootAt (targetLooker.target.transform);
			if (agent.remainingDistance > range) {
				animator.SetBool ("attacking", false);
				currentStat = Stats.MOVING;
			}
		}
	}
}
