using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public CanvasGameplay uiFacade;
	private int coins;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		UpdateMoney (200);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool ConsumeMoney(int value){
		if (coins - value >= 0) {
			UpdateMoney (coins - value);
			return true;
		}
		return false;
	}

	public void AddCoins(int value){
		UpdateMoney (coins + value);
	}

	private void UpdateMoney(int value){
		coins = value;
		uiFacade.SetMoney (coins);
	}
}
