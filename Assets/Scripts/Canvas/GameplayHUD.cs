using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUD : MonoBehaviour
{
    private int score;
    public Text ScoreText;
    public Text LifeText;

    public void Start()
    {
        score = 0;
        ScoreText.text = score.ToString("000000");
    }

    public void UpdateLifeText(int nlife)
    {
        LifeText.text = "x" + nlife.ToString("00");
    }

    public void UpdateScoreText(int nscore)
    {
        score += nscore;
        ScoreText.text = score.ToString("000000");
    }
}
