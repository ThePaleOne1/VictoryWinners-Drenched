using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;

    public float runSpeed;

    public float cameraSpeed;

    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horziontal"), Input.GetAxis("Vertical"));

            moveDirection *= walkSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
    }
}
