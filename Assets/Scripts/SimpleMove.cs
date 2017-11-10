using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMove : MonoBehaviour {

	public TargetLooker targetLooker;
	public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetLooker.target)
			agent.destination = targetLooker.target.transform.position;
		//transform.Translate (0, 0, 1 * Time.deltaTime);
	}
}
