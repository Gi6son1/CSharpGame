using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public ControllerDetection controller;
    // Start is called before the first frame update
    bool KMControl;
    bool CControl;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetButtonDown("JumpKey")) || (Input.GetButtonDown("HorizontalKey"))) && (Input.mousePresent))
        {
            KMControl = true; /*/ this IF statement defines the control method depending on what button on what controller is pressed. 
                                if a button on the keyboard is pressed, and a mouse is detected, then the control method is mouse and keyboard/*/
            CControl = false;
        }
        if ((Input.mousePresent) == false) //if mouse is not connected, then the control method is not set to keyboard and mouse
        {
            KMControl = false;
        }
        if ((Input.GetButtonDown("JumpCon")) || (Input.GetAxis("HorizontalCon") != 0) || (Input.GetAxis("RJoystickY") != 0) || (Input.GetAxis("RJoystickX") != 0) || (Input.GetButtonDown("JoystickGun") || Input.GetButtonDown("JoystickMelee")))
        {
            KMControl = false; /*/if a button on the controller is pressed, the control method is set as controller/*/   /*/the above lists all the possible
                                                                                                                             inputs that the player can make/*/
            CControl = true;
        }
        if (KMControl)
        {
            KMaim();//function for mouse aiming
        }
        if (CControl)
        {
            Caim();//function for controller aiming
        }
        

    }

    void KMaim()
    {
        Vector3 mousePos = Input.mousePosition; //the coordinates of the mouse on the screen are saved
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position); //the coordinates of the gun are are saved
        mousePos.x = mousePos.x - objectPos.x; //the horizontal distance from the gun to the mouse are created
        mousePos.y = mousePos.y - objectPos.y; //the vertical distance from the gun to the mouse are created
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; //the angle that the the distances create in a triangle is calculated
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90)); //the gun arm is rotated to that angle

    }
    void Caim()
    {
        float controlx = Input.GetAxis("RJoystickX"); //the horizontal direction of the joystick is saved
        float controly = Input.GetAxis("RJoystickY"); //the vertical direction of the joystick is saved
        float angle = Mathf.Atan2(controlx, controly) * Mathf.Rad2Deg; //the angle that the directions make in a triangle is calculated
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); //the arm is rotated to that angle
    }
    void ControlDetect()
    {

    }
}

