using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1;
        float distance = speed * Time.deltaTime;

        this.transform.Translate(0, 0, distance, Space.Self);
        
    }
}
