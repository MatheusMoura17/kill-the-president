using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMove : MonoBehaviour {

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
		if (targetLooker.target){
			agent.destination = targetLooker.target.transform.position;
			if (agent.remainingDistance > range) {
				animator.SetBool ("attacking", false);
				currentStat = Stats.MOVING;
			}
		}
	}
}
