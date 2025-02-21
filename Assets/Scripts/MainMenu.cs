using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Reset entry count when starting a new game
        PlayerPrefs.SetInt("SceneEntryCount", 0);

        // Optional: Reset the key as well if needed
        PlayerPrefs.SetInt("GotKey", 0);

        // Load the next level asynchronously
        SceneManager.LoadSceneAsync("Lv4");
    }
}
