using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumph;
    [SerializeField] float jumpforce;
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;

    Vector3 jump;
    Rigidbody myRigidbody;

    bool isgrounded;
    bool walking = true;
    bool isRunning = false;

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

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards
                (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);    
            }
            GetComponent<Animator>().SetFloat("Speed", speed);
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
                if(other.gameObject.tag == "Ground")
                isgrounded = true;
            }

    void PlayerRun()
    {
            if (Input.GetKey(KeyCode.LeftShift)) 
            {
                if (!isRunning)
            {
                isRunning = true;
                speed = runSpeed;
            }
                else {
                
                if (isRunning) 
                {
                    isRunning = false;
                    speed = walkSpeed;
                }
            }
        }   
    }
            
}          
         


    

    
