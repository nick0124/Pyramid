using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

    public Text youScoreTxt;
    public Text bestScoreTxt;

	// Use this for initialization
	void Start () 
    {
        YouScore();
        BestScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TryAgain()
    {
        Application.LoadLevel(1);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void YouScore()
    {
        youScoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void RessetScore()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public void BestScore()
    {
        if (PlayerPrefs.GetInt("BestScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("Score"));
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
        
    }
}
