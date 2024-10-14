using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetection : MonoBehaviour
{
    public bool KMControl; //defines if player is using Keyboard and Mouse
    public bool CControl; //defines if player is using controller
    // Start is called before the first frame update
    void Start()
    {
        KMControl = false; //resets both to false
        CControl = false;
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
        if ((Input.mousePresent) == false)
        {
            KMControl = false;
        }
        if ((Input.GetButtonDown("JumpCon")) || (Input.GetAxis("HorizontalCon") != 0) || (Input.GetAxis("RJoystickY") != 0) || (Input.GetAxis("RJoystickX") != 0) || (Input.GetButtonDown("JoystickGun") || Input.GetButtonDown("JoystickMelee")))  
        {
            KMControl = false; /*/if a button on the controller is pressed, the control method is set as controller/*/
            CControl = true;
        }
    }
}
