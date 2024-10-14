using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevelDeath : MonoBehaviour
{
    public GameObject deathPanel; //this will hold the player death panel gameobject
    public int room1Index; //this will hold the scene index of the 1st room, doing this rather than just stating the first room means if i were to make more levels, i wouldnt need another script
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Skin1") == null) //if the player is dead
        {
            StartCoroutine(Wait()); //start wait function
        }
    }
    IEnumerator Wait() //wait function
    {
        yield return new WaitForSeconds(1f); //wait for one second
        deathPanel.SetActive(true); //make the death panel visible
    }
    public void TryAgain() //this is the public function that is called if the player clicks "try again"
    {
        DontDestroyOnLoad(GameObject.Find("SaveFileLine")); //save file line game object will not be destroyed
        DontDestroyOnLoad(GameObject.Find("Selected Account")); //selected account game object will not be destroyed
        DontDestroyOnLoad(GameObject.Find("FlashLetter"));
        DontDestroyOnLoad(GameObject.Find("Music"));
        DontDestroyOnLoad(GameObject.Find("SoundFX"));
        SceneManager.LoadScene(room1Index); //the room 1 scene is loaded
    }
    public void MainMenu() //this is the function that is called if the player clicks "main menu"
    {
        DontDestroyOnLoad(GameObject.Find("Selected Account")); //selected account game object will not be destroyed
        SceneManager.LoadScene(1);  //main menu loaded
    }

}
