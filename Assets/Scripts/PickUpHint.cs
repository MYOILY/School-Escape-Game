using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    bool canPick; 
    bool GotKey;
    [SerializeField] GameObject target; 
    [SerializeField] TMP_Text hintUI; 

    void Start()
    {
        GotKey = false;
        PlayerPrefs.SetInt("GotKey", GotKey ? 1 : 0);
        if (hintUI != null)
        {
            hintUI.text = ""; 
        }
    }

    void Update()
    {
        if (canPick && Input.GetKeyDown(KeyCode.F))
        {
            target.SetActive(false); 
            hintUI.text = ""; 
            GotKey = true;
            PlayerPrefs.SetInt("GotKey", GotKey ? 1 : 0);  // Save 1 for true, 0 for false
            PlayerPrefs.Save();  // Make sure to save the PlayerPrefs
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPick = true; 
            if (hintUI != null)
            {
                hintUI.text = "Press F to Pick Up"; 
                Debug.Log("Player is in range"); 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPick = false; 
            if (hintUI != null)
            {
                hintUI.text = ""; 
            }
            Debug.Log("Player exited range"); 
        }
    }
}
