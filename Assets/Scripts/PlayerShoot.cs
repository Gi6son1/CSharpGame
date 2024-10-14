using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletEmitter; //calls the bullet emitter game object
    public GameObject PlayerBullet; //calls the player bullet game object
    public float BulletForwardForce; //this variable dictates how fast the bullet travels
    bool canshoot = true; //bool to determine if player can shoot 
    public ControllerDetection control; //will hold the controller detection script

    public AudioSource sound; //calls the audiosource component to use it

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("MouseGun")) || ((Input.GetAxis("JoystickGun") > 0.1) && canshoot)) //shoots when rightclick or controller bumper is pressed
        {
            if (GameObject.Find("MeleeArm(Clone)") == null && canshoot) //if the player is not meleeing and canshoot variable is true
            {
                if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if sound effects are set to on
                    sound.Play(); //play sound
                Shoot(control.CControl); //call shoot function with the bool taken from the controlller detection script
            }
        }
    }
    void Shoot(bool controller) //this is the function that handles the shooting and will use the bool taken from the update function
    {
        GameObject TemporaryBulletHandler; //creates a game object that will act as the bullet     /*/ this spawns the object as a bullet at the bullet emitter location/*/
        TemporaryBulletHandler = Instantiate(PlayerBullet,BulletEmitter.transform.position,BulletEmitter.transform.rotation) as GameObject;
        TemporaryBulletHandler.transform.Rotate(0f, 0f, -90f); //rotates bullet 90 degrees to make it come out straight
        Rigidbody2D TemporaryRigidBody; //creates a rigidbody variable that will control the physics for the bullet
        TemporaryRigidBody = TemporaryBulletHandler.GetComponent<Rigidbody2D>(); //calls the rigidbody2D component of the bullet
        TemporaryRigidBody.AddForce(-transform.up * BulletForwardForce); //fires the bullet outwards at the bulletforce that was set at the start
        Destroy(TemporaryBulletHandler, 4.0f); //destroys the bullet after 4 seconds, this means the computer won't be slowed down due to lots of objects in the game
        if (controller) //if player using a controller
            canshoot = false; //set to false
        StartCoroutine(Wait()); //wait function started
    }
    IEnumerator Wait() //wait function
    {
        yield return new WaitForSeconds(0.25f); //wait for 0.25 seconds
        canshoot = true; //set to true
    }
}
