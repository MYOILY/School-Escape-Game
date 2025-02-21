using System.Collections;
using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    public TMP_Text introText; // Reference to the TMP_Text component for the message
    public string firstEntryMessage = "Why did you come here... Find the notice on the wall for detailed instruction to escape";
    public string secondEntryMessage = "Backed? Open the door!";
    private const string EntryCountKey = "SceneEntryCount";
    public float displayDuration = 5f; // Display duration in seconds

    void Start()
    {
        int entryCount = PlayerPrefs.GetInt(EntryCountKey, 0);

        if (entryCount == 0)
        {
            DisplayMessage(firstEntryMessage);
        }
        else if (entryCount == 1)
        {
            introText.gameObject.SetActive(false);
        }
        else if (entryCount == 2)
        {
            DisplayMessage(secondEntryMessage);
        }
        PlayerPrefs.SetInt(EntryCountKey, entryCount + 1);
    }

    void DisplayMessage(string message)
    {
        introText.text = message;
        introText.gameObject.SetActive(true);
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        introText.gameObject.SetActive(false);
    }

    public void ResetEntryCount()
    {
        PlayerPrefs.SetInt(EntryCountKey, 0);
    }
}
