using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    [SerializeField] enum MovementState { Walking, Running };

    [SerializeField] float rotationSpeed;
    [SerializeField] float jumph;
    [SerializeField] float jumpforce;
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float moveSpeed;

    [SerializeField] MovementState currentState = MovementState.Walking;

    Vector3 jump;
    Rigidbody myRigidbody;  
    bool isgrounded;

    [SerializeField] private Animator animator;

    void Start()
    {
        jump = new Vector3(0f, jumph, 0f);
        myRigidbody = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        MovePlayer();
        PlayerJump();
        PlayerRun();

        void MovePlayer()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards
                (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            GetComponent<Animator>().SetFloat("Speed", moveSpeed);
        }
        void PlayerJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                myRigidbody.AddForce(jump * jumpforce, ForceMode.Impulse);
                isgrounded = false;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")|| other.gameObject.CompareTag("Platform"))
        {
            isgrounded = true;
        }
    }
    void PlayerRun()
    {
        if  (Input.GetKey(KeyCode.LeftShift) && currentState != MovementState.Running) 
        {
            currentState = MovementState.Running;
            moveSpeed = runSpeed;    
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && currentState != MovementState.Walking) 
        {
            currentState = MovementState.Walking;
            moveSpeed = walkSpeed;
        }         
    }    
}

    

    
