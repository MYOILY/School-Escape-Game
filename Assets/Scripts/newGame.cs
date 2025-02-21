using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour
{
    bool GotKey = false; 
    public void PlayGame()
    {
        GotKey = PlayerPrefs.GetInt("GotKey", 0) == 1;
        SceneManager.LoadSceneAsync("StartScene");
    }
    
}