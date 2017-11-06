using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform cannonTransform;
	public Transform targetEnemy;
	
	// Update is called once per frame
	void Update () {
		Vector3 position = targetEnemy.position;
		position.y = cannonTransform.position.y;
		cannonTransform.LookAt (position);
	}
}
