using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //enabling this allows me to see if a button has been selected
using UnityEngine.UI;

public class OnClickCurrentAccount : MonoBehaviour
{
    private void Update()
    {
    }
    public void clickedaccount() //this is used to see what account has been clicked
    {
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject; //returns the button that was clicked
        string text = buttonClicked.transform.GetChild(0).gameObject.GetComponent<Text>().text; //reads the text box of the clicked button
        string[] textData = text.Split('\n'); //splits the text into lines
        string fileName = textData[0]; //reads the first line to get the username
        GameObject.Find("Selected Account").GetComponent<Text>().text = fileName; //makes the selected account username the username that was read
    }
}
