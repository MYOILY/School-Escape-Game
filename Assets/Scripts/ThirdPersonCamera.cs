using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
   public Transform cameraTransform; // Assign the camera transform in the Inspector
    public Transform playerTransform;
    void Update()
{
    // Get the camera's forward direction
    Vector3 cameraForward = cameraTransform.forward;
    
    // Flatten the camera's forward vector on the Y axis to avoid tilting the player
    cameraForward.y = 0f;

    // If the camera is pointing in a valid direction (not straight up or down)
    if (cameraForward != Vector3.zero)
    {
        // Rotate the player to face the direction of the camera
        playerTransform.forward = cameraForward;
    }
}
}

/* [Header("References")]
    public Transform Orientation;
    public Transform Player;
    public Transform PlayerObj;
    public Rigidbody rb;
    public float rotationSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        Orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = Orientation.forward * verticalInput + Orientation.right*horizontalInput;
        if(inputDir != Vector3.zero){
            PlayerObj.forward = Vector3.Slerp(PlayerObj.forward, inputDir.normalized, Time.deltaTime*rotationSpeed);
        }

    }*/