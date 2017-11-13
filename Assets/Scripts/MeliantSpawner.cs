using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeliantSpawner : MonoBehaviour, ISpawner {

	public static MeliantSpawner instance;
	public GameObject alertPrefab;
	public GameObject moneyAlertPrefab;
	public GameObject meliantPrefab;
	private List<GameObject> spawnedMeliants;
	public int price;

	void Awake () {
		spawnedMeliants = new List<GameObject> ();
		instance = this;
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			Vector3 position=Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (position, Camera.main.transform.forward, out hit))
			if (hit.collider.gameObject.CompareTag ("Ground")) {
				if (GameManager.instance.ConsumeMoney (price)) {
					Spawn (hit.point, Quaternion.identity);
				} else {
					//não tem moedas suficientes
					Instantiate(moneyAlertPrefab,hit.point,Quaternion.identity);
				}
			} else {
				//clicou em uma area errada
				Instantiate(alertPrefab,hit.point,Quaternion.identity);
			}
		}
	}

	public GameObject Spawn(Vector3 position, Quaternion rotation){
		foreach (GameObject go in spawnedMeliants){
			if (!go.activeSelf) {
				go.GetComponent<Meliant> ().Reset ();
				go.transform.position = position;
				go.transform.rotation = rotation;
				go.SetActive (true);
				return go;
			}
		}

		GameObject tmpGo=Instantiate (meliantPrefab,position,rotation,transform);
		tmpGo.GetComponent<TargetLooker> ().elementSpawner = TowerSpawner.instance.gameObject;
		spawnedMeliants.Add(tmpGo);
		return tmpGo;
	}

	public GameObject[] GetSpawnedElements(){
		List<GameObject> actives = new List<GameObject>();
		foreach (GameObject element in spawnedMeliants)
			if (element.activeSelf)
				actives.Add (element);
		return actives.ToArray ();
	}
}
