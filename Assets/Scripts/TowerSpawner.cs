﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour, ISpawner {

	public TreeDecision tree;
	public static TowerSpawner instance;
	public GameObject towerPrefab;
	public List<GameObject> spawnedTowers;
	public float ratio = 4;
	private float counter;
	public float defaultY=0.64f;

	public Damagable presidentDamagable;
	public MeliantSpawner meliantSpawner;


	void Awake () {
		//spawnedTowers = new List<GameObject> ();
		instance = this;
	}

	void Update(){
		counter+=Time.deltaTime;
		if (counter >= ratio) {
			counter = 0;
			Vector3 position = Vector3.zero;
			position.y = defaultY;
			Vector2 position2d = tree.Compute (
				presidentDamagable.life,
				GetSpawnedElements().Length,
				meliantSpawner.GetSpawnedElements().Length,
				(int)GameManager.instance.time,
				GameManager.instance.coins
			);
			position.x = position2d.x;
			position.z = position2d.y;
			Spawn (position, Quaternion.identity);
		}
	}

	public GameObject Spawn(Vector3 position, Quaternion rotation){
		foreach (GameObject go in spawnedTowers){
			if (!go.activeSelf) {
				go.transform.position = position;
				go.transform.rotation = rotation;
				go.SetActive (true);
				return go;
			}
		}

		GameObject tmpGo=Instantiate (towerPrefab,position,rotation,transform);
		tmpGo.GetComponent<TargetLooker> ().elementSpawner = meliantSpawner.gameObject;
		spawnedTowers.Add(tmpGo);
		return tmpGo;
	}

	public GameObject[] GetSpawnedElements(){
		List<GameObject> actives = new List<GameObject>();
		foreach (GameObject element in spawnedTowers)
			if (element.activeSelf)
				actives.Add (element);
		return actives.ToArray ();
	}
}
