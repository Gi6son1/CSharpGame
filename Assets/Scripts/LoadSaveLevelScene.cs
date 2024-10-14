using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //enabling this allows me to see if a button has been selected
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSaveLevelScene : MonoBehaviour
{
    public void ClickedSave() //function called when a savefile button is clicked
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject; //returns the button that was clicked
        string text = buttonClicked.transform.GetChild(0).gameObject.GetComponent<Text>().text; //gets the "SaveFilenumber" title text of the button
        string[] textData = text.Split(' '); //splits it into "SaveFile" and the number
        string saveFileNumber = ((int.Parse(textData[1])) + 3).ToString(); //turns the number into an integer, adds 3, and then turns it back into a string
        string levelNumber = buttonClicked.transform.GetChild(2).gameObject.GetComponent<Text>().text; //reads the save level number text box of the clicked button
        new GameObject("SaveFileLine").AddComponent<Text>().text = (saveFileNumber); //makes savefileline gameobject, adds text component and sets text as the savefilenumber variable
        DontDestroyOnLoad(GameObject.Find("SaveFileLine")); //will not be destroyed when next scene loaded
        DontDestroyOnLoad(GameObject.Find("Selected Account"));
        DontDestroyOnLoad(GameObject.Find("Music"));
        DontDestroyOnLoad(GameObject.Find("SoundFX"));
        DontDestroyOnLoad(GameObject.Find("FlashLetter"));
        SceneManager.LoadScene("Level" + levelNumber + "Room1"); //loads first room of the level number on the clicked button

    }
}
