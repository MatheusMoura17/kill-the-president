using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	public float timeToDestoy=1.1f;

	// Use this for initialization
	void Start () {
		Invoke ("Destroy", timeToDestoy);
	}
	
	private void Destroy(){
		Destroy (gameObject);
	}
}
