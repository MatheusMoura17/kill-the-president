using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameplay : MonoBehaviour {

    public Canvas telaGameOver;
    public Canvas telaVitoria;

    public Button over;
    public Button Winner;

	// Use this for initialization
	void Start () {

        telaGameOver = GetComponent<Canvas>();
        telaVitoria = GetComponent<Canvas>();

        over = GetComponent<Button>();
        Winner = GetComponent<Button>();

        telaVitoria.enabled = false;
        telaGameOver.enabled = false;
	}
	
	public void GameOverPress()
    {
        telaGameOver.enabled = true;
        telaVitoria.enabled = false;
    }

    public void TelaVitoriaPress()
    {
        telaVitoria.enabled = true;
        telaGameOver.enabled = false;
    }

    public void MainMenuLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
