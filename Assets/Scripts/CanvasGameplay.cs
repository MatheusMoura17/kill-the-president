using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameplay : MonoBehaviour {

    public Canvas telaGameOver;
    public Canvas telaVitoria;
    public Canvas gameplay;

    public Button militantes;

    public Button over;
    public Button Winner;

	// Use this for initialization
	void Start () {

        telaGameOver = GetComponent<Canvas>();
        telaVitoria = GetComponent<Canvas>();
        gameplay = GetComponent<Canvas>();

        militantes = GetComponent<Button>();

        over = GetComponent<Button>();
        Winner = GetComponent<Button>();

        gameplay.enabled = true;
        telaVitoria.enabled = false;
        telaGameOver.enabled = false;
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
