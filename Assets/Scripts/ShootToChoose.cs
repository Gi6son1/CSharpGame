using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootToChoose : MonoBehaviour
{
    public int optionsceneindex; //allows me to define what scene will be loaded based on its index

    void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("Selected Account")); //will make sure that the selected account object isnt deleted when a new scene is loaded
        Debug.Log(GameObject.Find("Selected Account").GetComponent<Text>().text);
        DontDestroyOnLoad(GameObject.Find("Music"));
        DontDestroyOnLoad(GameObject.Find("SoundFX"));
        DontDestroyOnLoad(GameObject.Find("FlashLetter"));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //function called when object with trigger collides with box
    {
        if ((collision.transform.gameObject.tag.Equals("PlayerBullet")) || (collision.transform.gameObject.tag.Equals("PlayerMelee")))  //if object has the tag player attack 
        {
            SceneManager.LoadScene(optionsceneindex); //the scene is loaded
        }
    }
}
