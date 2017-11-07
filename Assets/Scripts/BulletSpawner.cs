using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour,ISpawner {

	public static BulletSpawner instance;

	public GameObject bulletPrefab;
	private List<GameObject> spawnedBullets;

	void Awake () {
		spawnedBullets = new List<GameObject> ();
		instance = this;
	}

	public GameObject SpawnBullet(Vector3 position, Quaternion rotation){
		foreach (GameObject go in spawnedBullets){
			if (!go.activeSelf) {
				go.transform.position = position;
				go.transform.rotation = rotation;
				go.SetActive (true);
				return go;
			}
		}

		GameObject tmpGo=Instantiate (bulletPrefab,position,rotation,transform);
		spawnedBullets.Add(tmpGo);
		return tmpGo;
	}

	public GameObject[] GetSpawnedElements(){
		List<GameObject> actives = new List<GameObject>();
		foreach (GameObject element in spawnedBullets)
			if (element.activeSelf)
				actives.Add (element);
		return actives.ToArray ();
	}

}
