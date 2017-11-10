using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Transform targetTransform;
	public int damage;

	void Update () {
		if (targetTransform) {
			transform.position = Vector3.MoveTowards (
				transform.position, 
				targetTransform.position, 
				speed * Time.deltaTime);

			if (Vector3.Distance (targetTransform.position, transform.position) == 0) {
				targetTransform = null;
				gameObject.SetActive (false);
			}
		}
	}
}
