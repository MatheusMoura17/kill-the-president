using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Damagable : MonoBehaviour {

	public Transform lifeBar;
	public int maxLife = 100;
	public int life;
	public string owner;
	public int coinsToDrop=0;
	public GameObject dropEffect;
	public Action onDestroy; 

	public void Reset(){
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
			if (bullet.owner != owner) {
				UpdateLife (life - bullet.damage);
			}
		}
	}

	void UpdateLife(int value){
		life = value >= 0 ? value: 0;
		Vector3 scale = lifeBar.localScale;
		scale.x = (life * 0.15f) / maxLife;
		lifeBar.localScale = scale;
		if (life == 0) {
			if (coinsToDrop != 0) {
				GameManager.instance.AddCoins (coinsToDrop);
				Vector3 position = transform.position;
				position.y = 10;
				position.z -= 5.3f;
				Instantiate (dropEffect,position,transform.rotation);
			}
			if (onDestroy != null)
				onDestroy.Invoke ();
			gameObject.SetActive (false);
		}
	}
}
