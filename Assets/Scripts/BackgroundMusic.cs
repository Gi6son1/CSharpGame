using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip music; //will hold the music audio file

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("BackgroundMusic") == null) //if the gameobject does not exist
        {
            AudioSource sound = new GameObject("BackgroundMusic").AddComponent<AudioSource>(); //creates new gameobject and adds audiosource component
            GameObject.Find("BackgroundMusic").AddComponent<MusicMute>();
            sound.clip = music; //sets the clip to the music file
            sound.Play(); //plays it
            sound.loop = true; //sets it to loop
            sound.volume = 0.25f; //reduces the volume to 50%
        }

        
    }
}
