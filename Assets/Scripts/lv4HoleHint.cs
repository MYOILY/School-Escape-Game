using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class lv4HoleHint : MonoBehaviour
{
    bool canJump; 
    [SerializeField] GameObject target; 
    [SerializeField] TMP_Text hintUI; 

    void Start()
    {
        if (hintUI != null)
        {
            hintUI.text = ""; 
        }
    }

    void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("lv1");
            hintUI.text = ""; 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canJump = true; 
            if (hintUI != null)
            {
                hintUI.text = "Press J to Jump"; 
            Debug.Log("Player is in range"); 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canJump = false; 
            if (hintUI != null)
            {
                hintUI.text = ""; 
            }
            Debug.Log("Player exited range"); 
        }
    }
}