using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnClickEvents : MonoBehaviour
{
    
    public void Play() 
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
