using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour {

    public Text youScoreTxt;
    public Text bestScoreTxt;

	// Use this for initialization
	void Start () {
        YouScore();
        BestScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Pause()
    {
        
    }

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        Application.LoadLevel(1);
    }

    public void YouScore()
    {
        youScoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void BestScore()
    {
        Debug.Log(bestScoreTxt.text);
        if (int.Parse(bestScoreTxt.text) < PlayerPrefs.GetInt("Score"))
            bestScoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
