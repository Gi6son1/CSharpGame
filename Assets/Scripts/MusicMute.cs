using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicMute : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Music").GetComponent<Text>().text == "on" && (!SceneManager.GetActiveScene().name.Contains("Boss"))) //if the music gameobject is set to on and not a boss scene
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().mute = false; //music is not muted
        else //otherwise
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().mute = true;  //music is muted
        DontDestroyOnLoad(GameObject.Find("BackgroundMusic")); //makes sure music continues through to the next scene
    }
}
