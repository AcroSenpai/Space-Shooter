using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHUD : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    // Use this for initialization
    void Start ()
    {
        scoreText.text = "Score:" + PlayerPrefs.GetInt("Score").ToString("000000");
        highScoreText.text = "HighScore:" + PlayerPrefs.GetInt("HighScore").ToString("000000");
    }

    public void LoadScrene(int numScene)
    {
        SceneManager.LoadScene(numScene);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
