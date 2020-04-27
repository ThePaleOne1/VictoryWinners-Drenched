using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float cameraSpeed;
    public float jumpHeight;

    private float jumpCooldown = 1.0f;

    public float gravity = 20f;

    private bool isWalking;
    private bool isRunning;
    public bool sprintEnabled;

    public bool Dead;

    public bool isPaused;

    public bool mouseLook;

    private Vector2 rotation = Vector2.zero;

    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

    PauseScript pause;

    Animator anim;
       
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();

        pause = FindObjectOfType<PauseScript>();

        sprintEnabled = true;

        mouseLook = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            anim.GetComponent<Animator>().SetBool("IsGrounded", true);

            if (!Dead)
            {
                Movement();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
            Debug.Log("grounded");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (sprintEnabled)
            {
                isRunning = true;
            }
            
        }
        else
        {
            isRunning = false;
        }

        if (!controller.isGrounded)
        {
            anim.GetComponent<Animator>().SetBool("IsGrounded", false);

            Debug.Log("falling");
        }
        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        if (mouseLook)
        {
            MouseLook();
        }

        if (jumpCooldown > 0)
        {
            jumpCooldown -= 1 * Time.deltaTime;
        }
    }

    void Movement()
    {
        float xSpeed = Input.GetAxis("Horizontal");

        float zSpeed = Input.GetAxis("Vertical");

        moveDirection = new Vector3(xSpeed, 0, zSpeed);

        moveDirection = Camera.main.transform.TransformDirection(moveDirection);

        if (!isRunning)
        {
            moveDirection *= walkSpeed * Time.deltaTime;

            anim.GetComponent<Animator>().SetBool("IsRunning", false);
        }

        if (isRunning)
        {
            moveDirection *= runSpeed * Time.deltaTime;

            anim.GetComponent<Animator>().SetBool("IsRunning", true);
        }

        if (xSpeed > 0 || xSpeed < 0 || zSpeed > 0 || zSpeed < 0)
        {
            anim.GetComponent<Animator>().SetBool("IsWalking", true);
        }
        else
        {
            anim.GetComponent<Animator>().SetBool("IsWalking", false);
        }
    }

    void Jump()
    {
        if(jumpCooldown <= 0)
        {
            moveDirection.y += jumpHeight * Time.deltaTime;
            jumpCooldown = 1f;
        }             
    }

    void MouseLook()
    {
        rotation.y += Input.GetAxis("Mouse X");

        rotation.x += -Input.GetAxis("Mouse Y");

        rotation.x = Mathf.Clamp(rotation.x, -30f, 10f);

        transform.eulerAngles = new Vector2(0, rotation.y) * cameraSpeed;

        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * cameraSpeed, 0, 0);
    }
}
