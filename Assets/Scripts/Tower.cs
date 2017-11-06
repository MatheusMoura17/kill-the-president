using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform cannonTransform;
	public Transform targetEnemy;

	void Update () {
		Vector3 position = targetEnemy.position;
		position.y = cannonTransform.position.y;
		cannonTransform.LookAt (position);
	}
}
