using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseDlg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Pause()
    {
        pauseDlg.SetActive(!pauseDlg.activeInHierarchy);
        if (pauseDlg.activeInHierarchy)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}
