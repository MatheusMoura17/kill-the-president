using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button jogar;

	// Use this for initialization
	void Start () {

        jogar = jogar.GetComponent<Button>();
	}
	
	public void GameplayLevel()
    {
        SceneManager.LoadScene("Game Play");
    }
}
