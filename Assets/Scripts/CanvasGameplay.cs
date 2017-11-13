using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CanvasGameplay : MonoBehaviour {

	public GameObject telaGameOver;
	public GameObject telaVitoria;
	public GameObject gameplay;

    public Text moeda;
	public Text timer;

    void Start()
    {
		telaVitoria.SetActive(false);
		telaGameOver.SetActive(false);
    }

	//Método para adcionar moeda
	public void SetMoney(int value)
    {
		moeda.text = value.ToString ();
    }

	public void ShowGameOver()
    {
		gameplay.SetActive(false);
		telaGameOver.SetActive(true);
		telaVitoria.SetActive(false);
    }

    public void ShowGameWin()
    {
		gameplay.SetActive(false);
		telaVitoria.SetActive(true);
		telaGameOver.SetActive(false);
    }

	public void UpdateTimer(int seconds){
		TimeSpan t = TimeSpan.FromSeconds (seconds);
		if (seconds <= 60) {
			timer.text = seconds.ToString ("00");
		} else {
			timer.text = t.Minutes+":"+t.Seconds.ToString("00");
		}
	}

    public void MainMenuLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }

	public void ReOpenLevel()
	{
		SceneManager.LoadScene("Game Play");
	}
 
}
