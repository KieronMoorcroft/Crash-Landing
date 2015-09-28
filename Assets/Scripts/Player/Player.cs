using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    public int currScore = Generate.score;
    private int highScore;
	// Force of the jump when tapped
    public Vector2 jumpForce = new Vector2(0,300);
    public bool showGameOver = true;
    public Text secondHigh;
    public Text highScoreText;
	// Update is called once per frame
	void Update () {
	    
        //if jump
        if (Input.GetKeyUp("space"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }

        //Die when off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y <0)
        {
            Die();
        }
        if (showGameOver && currScore > highScore)
        {
            // Sets the current to highscore if higher
            highScore = currScore;
            //Save the current highscore
            PlayerPrefs.SetInt("Highscore", highScore);
        }
        if (currScore < PlayerPrefs.GetInt("Highscore"))
        {
            //saves the new score
            PlayerPrefs.SetInt("Highscore", currScore);
            secondHigh.text = "Second Highscore" + PlayerPrefs.GetInt("Highscores");

        }
	}
    //Collision Events
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Die();
        }
    }

    //Die method restart level
    void Die()
    {
        Application.LoadLevel(1);
    }
}
