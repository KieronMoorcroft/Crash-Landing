using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerFin : MonoBehaviour {

    public GameObject pausePanel;
    public bool IsPaused;

	// Use this for initialization
	void Start () {
        IsPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
	
        if (IsPaused)
        {
            PauseGame(true);//show pause
        }
        else
        {
            PauseGame(false);
        }
        if(Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }

	}
    void PauseGame(bool state)
    {
        if(state)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }
    }
    public void switchPause()
    {
        if(IsPaused)
        {
            IsPaused = false;
        }
        else
        {
            IsPaused = true;
        }
    }
    public void QuitLevel()
    {
        Application.LoadLevel(0);
    }
}
