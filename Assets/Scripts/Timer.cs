using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 420;  // 7 minutes
    public TMP_Text timerText;
    private static float timeValueStatic;
    private static bool isInitialized = false;
    private static Timer instance;

    void Start()
    {
        RectTransform rectTransform = timerText.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        rectTransform.anchoredPosition = new Vector2(10, -10);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (!isInitialized)
            {
                timeValueStatic = timeValue;
                isInitialized = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (timeValueStatic > 0)
        {
            timeValueStatic -= Time.deltaTime;
            DisplayTime(timeValueStatic);

            if (timeValueStatic <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("GameOver");
                isInitialized = false;
            }
        }
    }

    public void ResetTimer()
    {
        timeValueStatic = timeValue;
        isInitialized = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}