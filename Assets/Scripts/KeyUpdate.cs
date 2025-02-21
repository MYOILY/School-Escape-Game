using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUpdate : MonoBehaviour
{
    bool GotKey; 
    // Start is called before the first frame update
    void Start()
    {
        GotKey = false;
        PlayerPrefs.SetInt("GotKey", GotKey ? 1 : 0);  // Save 1 for true, 0 for false
        PlayerPrefs.Save();
    }

}
