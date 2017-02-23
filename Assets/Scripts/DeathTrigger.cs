using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

    public bool hasLost = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        PlayerPrefs.SetInt("Score", 0);
        Application.LoadLevel(2);
        int score = FindObjectOfType<Spawner>().score;
        PlayerPrefs.SetInt("Score", score);
        if (PlayerPrefs.GetInt("BS") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("BS", PlayerPrefs.GetInt("Score"));
        //Debug.Log(PlayerPrefs.GetInt("BS"));
    }
}
