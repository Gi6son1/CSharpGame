using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour
{
    public float milliseconds = 0f; //this will hold the current score, set to 0 as default

    void Update() //every frame
    {
        if (GameObject.Find("Skin1") != null) //if player is still alive
        {
            milliseconds += (Time.deltaTime * 100); //milliseconds goes up by the time.delta time
            gameObject.GetComponent<Text>().text = ((int)milliseconds).ToString(); //changes the text component of gameobject to integer version of the milliseconds variable
        }

    }
}
