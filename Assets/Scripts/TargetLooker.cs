using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLooker : MonoBehaviour {

	public GameObject elementSpawner;
	[HideInInspector]
	public GameObject target;
	private ISpawner spawner;

	void Start(){
		spawner = elementSpawner.GetComponent<ISpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		target=GetApproxElement ();
	}

	private GameObject GetApproxElement(){
		GameObject[] targets = spawner.GetSpawnedElements ();
		if (targets.Length == 0)
			return null;
		else {
			GameObject bestElement=targets[0];
			float bestDistance = Vector3.Distance (transform.position, targets [0].transform.position);
			foreach (GameObject gm in targets) {
				float distance=Vector3.Distance (transform.position, gm.transform.position);
				if (distance < bestDistance) {
					bestDistance = distance;
					bestElement = gm;
				}
			}
			return bestElement;
		}
	}
}
