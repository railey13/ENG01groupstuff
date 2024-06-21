using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController PB;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private float groundDistance = 1f;
    [SerializeField] private float jumpHeight = 2f;

    private Vector3 velocity;

    void Start()
    {
        
    }

    void Update()
    {
        this.PlayerMovement();
    }

    void PlayerMovement() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        this.velocity.y += this.gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && PB.isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (PB.isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        PB.Move(move * this.playerSpeed * Time.deltaTime);

        PB.Move(velocity * Time.deltaTime);

    }
}
