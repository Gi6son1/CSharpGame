using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextRoom : MonoBehaviour
{
    public int sceneIndex; //this will hold the index number of the next room scene

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").GetLength(0) == 0) //if there are no enemies in the scene (all dead)
        {
            Debug.Log(GameObject.Find("SaveFileLine").GetComponent<Text>().text);
            StartCoroutine(Wait()); //start wait function
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f); //wait for 1 second
        DontDestroyOnLoad(GameObject.Find("Skin1")); //player will not be destroyed
        DontDestroyOnLoad(GameObject.Find("SaveFileLine")); //savefile line gameobject will not be destroyed
        DontDestroyOnLoad(GameObject.Find("Selected Account")); //selected account will not be destroyed
        DontDestroyOnLoad(GameObject.Find("Music"));
        DontDestroyOnLoad(GameObject.Find("SoundFX"));
        DontDestroyOnLoad(GameObject.Find("FlashLetter"));
        SceneManager.LoadScene(sceneIndex); //load next room
    }
}
