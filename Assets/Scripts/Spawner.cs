using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject[] rockPrefabs;
    public float nextFire = 1f;
    public float fireDelay = 1f;
    public float fireVelocity = 10f;
    public int score;
    public Text scoreLable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        /*
        if(GameObject.FindObjectOfType<DeathTrigger>().hasLost)
        {
            return;
        }
         */
        nextFire -= Time.deltaTime;

        if(nextFire <= 0)
        {
            nextFire = fireDelay;
            GameObject rockGO = (GameObject) Instantiate(rockPrefabs[Random.Range(0, rockPrefabs.Length)], transform.position, transform.rotation);
            score++;
            scoreLable.text = score.ToString();
            rockGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, fireVelocity);
            //GameObject.FindObjectOfType<ScoreManager>().score++;
        }
    }
}
