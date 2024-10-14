using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMusic : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Music").GetComponent<Text>().text == "on") //if the music gameobject is set to on
            gameObject.GetComponent<AudioSource>().mute = false; //music is not muted
        else //otherwise
            gameObject.GetComponent<AudioSource>().mute = true;  //music is muted
    }
}
