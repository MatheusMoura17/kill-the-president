using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {

	public Transform lifeBar;
	public int maxLife = 100;
	private int life;

	void Reset(){
		UpdateLife(maxLife);
	}

	void Start(){
		UpdateLife(maxLife);
	}

	void Update(){
		Vector3 target = Camera.main.transform.position;
		target.x = lifeBar.position.x;
		target.y = lifeBar.position.y;
		lifeBar.LookAt (target);
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Bullet") {
			Bullet bullet = col.GetComponent<Bullet> ();
			UpdateLife (life - bullet.damage);
			if (life <= 0)
				gameObject.SetActive (false);
		}
	}

	void UpdateLife(int value){
		life = value >= 0 ? value: 0;
		Vector3 scale = lifeBar.localScale;
		scale.x=life*0.001f;
		lifeBar.localScale = scale;
	}
}
