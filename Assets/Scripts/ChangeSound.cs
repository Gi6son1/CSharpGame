using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    public void Change(string settingToChange) //function called when clicked and uses the inputted name of the option gameobject to be changed
    {
        if (GameObject.Find(settingToChange).GetComponent<Text>().text == "on") //iff it says on
        {
            GameObject.Find(settingToChange).GetComponent<Text>().text = "off"; //change to off
        }
        else //otherwise
        {
            GameObject.Find(settingToChange).GetComponent<Text>().text = "on"; //change to on
        }
    }
}
