using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameplay : MonoBehaviour {

    public Canvas telaGameOver;
    public Canvas telaVitoria;
    public Canvas gameplay;

    public Text moeda;

    void Start()
    {
        telaVitoria.enabled = false;
        telaGameOver.enabled = false;
    }

	//Método para adcionar moeda
	public void SetMoney(int value)
    {
		moeda.text = value.ToString ();
    }

	public void GameOverPress()
    {
        gameplay.enabled = false;
        telaGameOver.enabled = true;
        telaVitoria.enabled = false;
    }

    public void TelaVitoriaPress()
    {
        gameplay.enabled = false;
        telaVitoria.enabled = true;
        telaGameOver.enabled = false;
    }

    public void MainMenuLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }
 
}
