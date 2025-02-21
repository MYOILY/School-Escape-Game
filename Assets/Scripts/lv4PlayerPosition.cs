using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public object DialogueUI { get; internal set; }

    void Awake()
    {
        LoadPlayerPosition();
    }

    void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey("ReturnX"))
        {
            float x = PlayerPrefs.GetFloat("ReturnX");
            float y = PlayerPrefs.GetFloat("ReturnY");
            float z = PlayerPrefs.GetFloat("ReturnZ");
            transform.position = new Vector3(x, y, z);
            Debug.Log("Player position set to: " + transform.position);
        }
    }
}
