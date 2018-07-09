using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public float tiempo = 0.0f;

    void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo >= 5f || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Hola");
            SceneManager.LoadScene(1);
        }
    }
}
