using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class noticeback : MonoBehaviour
{
    [SerializeField] TMP_Text hintUI;

    void Start()
    {

        hintUI.text = "Press F to Go Back";
        
        RectTransform rectTransform = hintUI.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(500, rectTransform.sizeDelta.y); 
        rectTransform.anchorMin = new Vector2(0, 1); 
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);      
        rectTransform.anchoredPosition = new Vector2(50, -50);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Lv4");
            hintUI.text = ""; 
        }
    }
}
