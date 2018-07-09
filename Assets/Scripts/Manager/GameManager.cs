using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public int score;
    public bool gamePause;

    private HUD hud;
    private SpawnerManager sm;
    private void Awake()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        sm = GetComponent<SpawnerManager>();
        score = 0;
        hud.UpdateScoreText(score);
    }

    public void Pause()
    {
        gamePause = true;
        hud.OpenPausePanel();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        gamePause = false;
        hud.ClosePausePanel();
        Time.timeScale = 1;
    }

    public void LoadScrene(int numScene)
    {
        SceneManager.LoadScene(numScene);
    }

    public void AddScore(int nscore)
    {
        score += nscore;
        hud.UpdateScoreText(score);
        sm.GetScore(nscore);




    }
    /*
    public void SpawnPU(Vector3 position)
    {
        new PowerUp(position);
    }
    */
    private void SaveGame()
    {
        int highScore = 0;

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        if(score > highScore)
        {
            highScore = score;
        }

        PlayerPrefs.SetInt("Score",score);
        PlayerPrefs.SetInt("HighScore", highScore);

    }

    public void GameOver()
    {
        gameOver = true;
        SaveGame();
        LoadScrene(3);
    }

    public void PlayerLife(int plife)
    {
        hud.UpdatePlayerText(plife);
    }
}
