using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool direction;
    private bool canJump; //determines whether player can jump or not
    // Start is called before the first frame update
    public int jumpPower;
    public float playerSpeed;

    public Animator animator; //this will reference the animator component
    public ControllerDetection controller; //will reference the controller detection script

    void Start()
    {
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        KeyboardMouse(); //here i am calling both the control functions so that both controls can be used to move the player
        Controller();

    }
    void KeyboardMouse() //keyboard controls
    {
        float horizontal = Input.GetAxis("HorizontalKey"); //this receives the input from either A/D keys or left/right arrow keys
        if (controller.KMControl) //if player is using keyboard and mouse
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("HorizontalKey"))); //sets speed variable to the positive version of the key input
        if ((horizontal < 0) && direction) //if the movement direction is left and player is facing right
        {
            direction = false; //direction bool is set to false (left)
            flip(); //flip function called
        }
        if ((horizontal > 0) && (direction == false)) //if movement direction is right and player is facing left
        {
            direction = true; //direcion set to true (right)
            flip(); //flip function called
        }
        Vector2 position = transform.position; // defines where the sprite is located
        position.x = position.x + playerSpeed * horizontal * Time.deltaTime; //moves the sprite left or right or nothing
        transform.position = position; //updates the x-axis position of the sprite                              
        if ((Input.GetButtonDown("JumpKey")) && (canJump)) //if either W or up arrow is pushed
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower); //pushes the sprite upwards at force 700.
        }
    }
    void Controller() //controller controls
    {
        float horizontal = Input.GetAxis("HorizontalCon"); //this receives the input from left joystick tilt
        if (controller.CControl) //if using controller
                animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("HorizontalCon"))); //sets speed variable to the positive version of the joystick axis
        if ((horizontal < 0) && direction) 
        {
            direction = false;
            flip();
        }
        if ((horizontal > 0) && (direction == false))
        {
            direction = true;
            flip();
        }
        Vector2 position = transform.position; // defines where the sprite is located
        position.x = position.x + 9.0f * horizontal * Time.deltaTime; //moves the sprite 7 units left or right or nothing
        transform.position = position; //updates the x-axis position of the sprite
        if ((Input.GetButtonDown("JumpCon")) && (canJump)) //if A is pushed
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower); //pushes the sprite upwards at force 700.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //function that activates when player is colliding with a platform
    {
        if (collision.transform.gameObject.tag.Equals("Platform"))
        {
            canJump = true; //player can jump
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag.Equals("Platform"))
        {
            canJump = true; //player can jump
        }
    }
    private void OnCollisionExit2D(Collision2D collision) //function that activates when player stops colliding with a platform
    {
        if (collision.transform.gameObject.tag.Equals("Platform"))
        {
            canJump = false; //player can jump
        }
    }
    void flip() //this function flips the player
    {
        Vector3 theScale = transform.localScale; //player sprite scale is defined
        theScale.x *= -1f; //the x-axis scale is reversed
        transform.localScale = theScale; //the new scale is set to the player
    }
}
