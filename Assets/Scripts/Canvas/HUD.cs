using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject pusePanel;
    public GameObject Music;
    public GameObject MusicP;
    public Text ScoreText;
    public Text LifeText;
    // Use this for initialization
    void Start ()
    {
        ClosePausePanel();
    }

    public void OpenPausePanel()
    {
        pusePanel.SetActive(true);
        Music.SetActive(false);
        MusicP.SetActive(true);
    }

    public void ClosePausePanel()
    {
        pusePanel.SetActive(false);
        Music.SetActive(true);
        MusicP.SetActive(false);
    }

    public void UpdateScoreText(int nscore)
    {
        ScoreText.text = nscore.ToString("000000");
    }

    public void UpdatePlayerText(int plife)
    {
        LifeText.text = "X" + plife.ToString("00");
    }
}
