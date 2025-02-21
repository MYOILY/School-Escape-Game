using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;
        public string text;
    }

    public TextMeshProUGUI textComponent;
    public GameObject dialoguePanel; 
    public List<DialogueLine> lines = new List<DialogueLine>();
    public float textSpeed;

    private int index;
    private bool isPlayerNear = false;

    void Start()
    {
        InitializeDialogueLines();
        textComponent.text = string.Empty;
        dialoguePanel.SetActive(false); // Hide dialogue on start
    }

    void Update()
    {
        if (isPlayerNear && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == FormatLine(lines[index]))
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = FormatLine(lines[index]);
            }
        }
    }

 void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            StopDialogue();
        }
    }

    void InitializeDialogueLines()
    {
        lines.Add(new DialogueLine { speaker = "Akane", text = "Who are you?" });
        lines.Add(new DialogueLine { speaker = "Unknown Girl", text = "I'm the student who entered room 404 before." });
        lines.Add(new DialogueLine { speaker = "Unknown Girl", text = "I know you are here to find the key as I failed..." });
        lines.Add(new DialogueLine { speaker = "Unknown Girl", text = "I guess the key is in the classroom with the door open." });
        lines.Add(new DialogueLine { speaker = "Akane", text = "Thank you!" });
    }

    void StartDialogue()
    {
        index = 0;
        dialoguePanel.SetActive(true);
        NextLine();
    }

    IEnumerator TypeLine()
    {
        foreach (char c in FormatLine(lines[index]).ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    string FormatLine(DialogueLine line)
    {
        return line.speaker + ": " + line.text;
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StopDialogue();
        }
    }

    void StopDialogue()
    {
        gameObject.SetActive(false);
        dialoguePanel.SetActive(false);
    }
}
