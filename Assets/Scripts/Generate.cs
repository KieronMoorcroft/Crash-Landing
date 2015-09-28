using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Generate : MonoBehaviour {



    public GameObject fuel;
    public GameObject rock;
    public GameObject rockDown;
    public GameObject scoreImage;
    public Text scoreText;
    public static int score = 0;
    

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateObstacle", 1f, 3f);
	}
	
    void Update()
    {
        DisplayScore();
    }
    void CreateObstacle() {

        Instantiate(rock);
        Instantiate(rockDown);
        Instantiate(fuel);

        score++;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

}
