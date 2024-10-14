using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    public GameObject controlmessage;  //these call the message boxes so that i can modify them
    public GameObject keyboardmessage; 
    public GameObject nocontrolmessage;
    bool KMControl; //defines if player is using Keyboard and Mouse
    bool CControl;//defines if player is using controller

    // Start is called before the first frame update
    void Start()
    {
        KMControl = false; //sets both bools to false
        CControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetButtonDown("JumpKey")) || (Input.GetButtonDown("HorizontalKey"))) && (Input.mousePresent))
        {
            KMControl = true; // this IF statement defines the control method depending on what button on what controller is pressed.
            CControl = false;   //if a button on the keyboard is pressed, and a mouse is detected, then the control method is mouse and keyboard

        }
        if ((Input.mousePresent) == false) //if no mouse is conneted
        {
            KMControl = false; //it is set to false
        }
        if ((Input.GetButtonDown("JumpCon")) || (Input.GetAxis("HorizontalCon") != 0) || (Input.GetAxis("RJoystickY") != 0) || (Input.GetAxis("RJoystickX") != 0) || (Input.GetButtonDown("JoystickGun") || Input.GetButtonDown("JoystickMelee")))
        {
            CControl = true;
            KMControl = false; //if a button on the controller is pressed, the control method is set as controller
        }
        if (KMControl) //if keyboard is used
        {
            controlmessage.SetActive(false); //only the keyboard message is shown
            keyboardmessage.SetActive(true);
            nocontrolmessage.SetActive(false);
        }
        if (CControl) //if controller is used
        {
            controlmessage.SetActive(true); //only controller message is shown
            keyboardmessage.SetActive(false);
            nocontrolmessage.SetActive(false);
        }
        if (!Input.mousePresent && (Input.GetJoystickNames().Length) == 0) //if no mouse or controller is connected
        {
            controlmessage.SetActive(false); //only nocontrol message is shown
            keyboardmessage.SetActive(false);
            nocontrolmessage.SetActive(true);
        }

    }
}
