using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameplay : MonoBehaviour {

    public Canvas telaGameOver;
    public Canvas telaVitoria;
    public Canvas gameplay;

    public Button militantes;
    public Text moeda;

    public Button over;
    public Button Winner;

    void Start()
    {

        telaVitoria.enabled = false;
        telaGameOver.enabled = false;
    }

    void Update () {

        telaGameOver = GetComponent<Canvas>();
        telaVitoria = GetComponent<Canvas>();
        gameplay = GetComponent<Canvas>();

        militantes = GetComponent<Button>();
        moeda = GetComponent<Text>();

        over = GetComponent<Button>();
        Winner = GetComponent<Button>();

	}

    // Método para colocar os militantes na tela
    public void AdicionandoMilitantes()
    {

    }

	//Método para adcionar moeda
    public void Money()
    {

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
