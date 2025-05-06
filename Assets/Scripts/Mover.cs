using UnityEngine;

public class Mover : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 300f;
    [SerializeField] float jumpSpeed = 10f;

    CharacterController characterController;
    float ySpeed;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
  
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");

       Vector3 movementDirection = new Vector3(horizontalInput, 0 , verticalInput);
       float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;
       movementDirection.Normalize();

       ySpeed += Physics.gravity.y * Time.deltaTime;

       if (Input.GetButtonDown("Jump"))
       {
           ySpeed = jumpSpeed;
       }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

       if (movementDirection != Vector3.zero)
       {
           Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
           transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
       }
    }
}
