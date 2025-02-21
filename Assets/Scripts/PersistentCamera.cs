using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentCamera : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
