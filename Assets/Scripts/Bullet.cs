using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed=10;
	public Transform targetTransform;

	void Update () {
		if (targetTransform) {
			transform.position = Vector3.MoveTowards (
				transform.position, 
				targetTransform.position, 
				speed * Time.deltaTime);

			if ((int)Vector3.Distance (targetTransform.position, transform.position) == 0) {
				targetTransform = null;
				gameObject.SetActive (false);
			}
		}
	}
}
