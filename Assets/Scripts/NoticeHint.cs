using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NoticeHint : MonoBehaviour
{
    bool canRead; 
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
        if (canRead && Input.GetKeyDown(KeyCode.F))
        {
            Vector3 currentPosition = target.transform.position;
            PlayerPrefs.SetFloat("ReturnX", currentPosition.x);
            PlayerPrefs.SetFloat("ReturnY", currentPosition.y);
            PlayerPrefs.SetFloat("ReturnZ", currentPosition.z);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Notice");
            if (hintUI != null)
            {
                hintUI.text = ""; 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canRead = true; 
            if (hintUI != null)
            {
                hintUI.text = "Press F to Read Notice"; 
            }
            Debug.Log("Player is in range"); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canRead = false; 
            if (hintUI != null)
            {
                hintUI.text = ""; 
            }
            Debug.Log("Player exited range"); 
        }
    }
}
