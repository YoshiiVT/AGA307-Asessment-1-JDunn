using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to Character Controller
    public CharacterController controller;

    //Reference for speed controll
    public float speed = 6f;
    public float walking = 6f;
    public float sprinting = 12f;
    public bool isSprinting;

    //These references are our variables to simulate gravity
    Vector3 velocity;
    public float gravity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    //This allows us to set what objects the groundcheck should search for
    public LayerMask groundMask;
    bool isGrounded;

    //Jump Height
    public float jumpHeight = 3f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // GroundDistance is the radius of the sphere, the layermask is GroundMask

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //These are our input registers
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Movement in a direction that our inputs go into
        Vector3 move = transform.right * x + transform.forward * z;
        //What is above tells the computer what direction we want to go by the way we are facing and what inputs we put in.
        // If we use "Vector3 move = new Vector3(x, 0f, z);" it will work moving us on global coordinates, but it wont move us in the direction we face.
        // However we still need to add a "motor" that moves us, which is the character controller

        controller.Move(move * speed * Time.deltaTime);
        //Controlle.Move is a prewritten instruction that moves a Vector 3 in the brackets
        //Remember "Time.deltaTime" makes a variable frame rate independant

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //More important physics shit, basically " V=Square Root (Jumpheight x -2 x G) "

        //Check to see the sprint key is down and is grounded
        if (Input.GetButton("Fire3") && isGrounded)
        {
            //Set speed to sprint speed
            isSprinting = true;
        }
        else 
        { 
            //Set speed to walk speed
            isSprinting = false; 
        } 
        
        //Speed modifiers
        if(isSprinting == true)
        {
            speed = sprinting;
        }

        if (isSprinting == false)
        {
            speed = walking;
        }

        velocity.y += gravity * Time.deltaTime;
        //This is all just physics and math stuff that brendan can yell at me later...
        controller.Move(velocity * Time.deltaTime);
        //Velocity Formula " V = 1/2Gravity x Time(Squared) " 
    }
}
