using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    // Variables for movement
    public float mouseSensitivity = 100f;
    public float speed = 12f;

    public Transform playerBody;
    public CharacterController controller;

    // Variables for gravity
    Vector3 velocity;
    public float gravity = -9.81f;

    // Variables for jumping
    public float jumpHeight = 3f;

    // Update is called once per frame

    public int cubeCount;
    public GameObject floor;
    public GameObject wall;
    public GameObject ramp;

    void Update()
    {
        PlayerMover();
        ApplyGravity();
        ProcessJumping();
        SpawnBlocks();
    }

    void PlayerMover()
    {
        // Turn player based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        // Move player based on keyboard presses
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void ProcessJumping()
    {
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void SpawnBlocks()
    {
        if(Input.GetKeyDown(KeyCode.E) && cubeCount >= 1)
        {
            Vector3 playerPos = this.transform.position;
            Vector3 playerDirection = this.transform.forward;
            Quaternion playerRotation = this.transform.rotation;

            Vector3 cubePos = playerPos + playerDirection * 3;
            Instantiate(floor, cubePos, playerRotation);
            //cubeCount -= 1;
            
        }
        if (Input.GetKeyDown(KeyCode.Q) && cubeCount >= 1)
        {
            Vector3 playerPos = this.transform.position;
            Vector3 playerDirection = this.transform.forward;
            Quaternion playerRotation = this.transform.rotation;

            Vector3 cubePos = playerPos + playerDirection * 3;
            Instantiate(wall, cubePos, playerRotation);
            //cubeCount -= 1;

        }
        if (Input.GetKeyDown(KeyCode.R) && cubeCount >= 1)
        {
            Vector3 playerPos = this.transform.position;
            Vector3 playerDirection = this.transform.forward;
            Quaternion playerRotation = this.transform.rotation;

            Vector3 cubePos = playerPos + playerDirection * 3;
            Instantiate(ramp, cubePos, playerRotation);
            //cubeCount -= 1;

        }
    }
}
