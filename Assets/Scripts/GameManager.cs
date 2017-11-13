using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private int coins;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool ConsumeMoney(int value){
		if (coins - value >= 0) {
			coins -= value;
			return true;
		}
		return false;
	}

	public void AddCoins(int value){
		coins += value;
	}
}
