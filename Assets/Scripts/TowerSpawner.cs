using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour, ISpawner {

	public static TowerSpawner instance;
	public GameObject towerPrefab;
	public List<GameObject> spawnedTowers;

	void Awake () {
		//spawnedTowers = new List<GameObject> ();
		instance = this;
	}

	void Update(){
		//if (Input.GetMouseButtonDown (0)) {
		//	Vector3 position=Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//	RaycastHit hit;
		//	if(Physics.Raycast(position,Camera.main.transform.forward, out hit))
		//		Spawn (hit.point,Quaternion.identity);
		//}
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
