using UnityEngine;

public class Mover : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed;


    void Start()
    {
        PrintInstruction();
    }

    
    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move using arrow keys or wasd");
        Debug.Log("Don't bump into objects");
    }

    void MovePlayer()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");

       Vector3 movementDirection = new Vector3(horizontalInput, 0 , verticalInput);
       transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

       if (movementDirection != Vector3.zero)
       {
           Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
           transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
       }
    }
}
