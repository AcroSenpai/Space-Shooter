using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Hola");
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Debug.Log("Adios");
        Application.Quit();
    }

}
