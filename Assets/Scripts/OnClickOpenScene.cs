using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //enabling this part of the engine allows me to change scenes

public class OnClickOpenScene : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Selected Account")); //makes sure that the SelectedAccount game object is not destroyed when the next scene is loaded
        DontDestroyOnLoad(GameObject.Find("Music"));
        DontDestroyOnLoad(GameObject.Find("SoundFX"));
        DontDestroyOnLoad(GameObject.Find("FlashLetter"));
    }
    public void LoadByIndex(int sceneIndex) //creates a public function that allows me to choose what scene to load (via its index in the project settings)
    {
        SceneManager.LoadScene(sceneIndex); //uses the enabled part of the engine to load the scene that corresponds to the entered index number
    }
}
