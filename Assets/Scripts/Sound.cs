using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    // Awake is called before the Start function
    void Awake()
    {
        if (GameObject.Find("Music") == null) //if there is no music gameobject
        {
            new GameObject("Music").AddComponent<Text>().text = "on"; //create one and add a text component to it, and make the text "on"
        }
        if (GameObject.Find("SoundFX") == null) //if there is no music gameobject
        {
            new GameObject("SoundFX").AddComponent<Text>().text = "on"; //create one and add a text component to it, and make the text "on"
        }
    }

}
