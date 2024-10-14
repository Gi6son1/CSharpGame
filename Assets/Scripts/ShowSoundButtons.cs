using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSoundButtons : MonoBehaviour
{
    public GameObject musicOn; //calls the ON text image of the music button so i can modify it
    public GameObject musicOff; //calls the OFF text image of the music button so i can modify it
    public GameObject soundFXOn; //calls the ON text image of the soundFX button so i can modify it
    public GameObject soundFXOff; //calls the OFF text image of the soundFX button so i can modify it

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Music").GetComponent<Text>().text == "on") //if music gameobject says "on"
        {
            musicOn.SetActive(true); //ON image appears
            musicOff.SetActive(false);  //OFF image disappears
        }
        if (GameObject.Find("Music").GetComponent<Text>().text == "off") //if music gameobject says "off"
        {
            musicOn.SetActive(false);  //ON image disappears
            musicOff.SetActive(true); //OFF image appears
        }
        if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if soundFX gameobject says "on"
        {
            soundFXOn.SetActive(true); //ON image appears
            soundFXOff.SetActive(false); //OFF image disappears
        }
        if (GameObject.Find("SoundFX").GetComponent<Text>().text == "off") //if soundFX gameobject says "off"
        {
            soundFXOn.SetActive(false); //ON image disappears
            soundFXOff.SetActive(true); //OFF image appears
        }
    }
}
