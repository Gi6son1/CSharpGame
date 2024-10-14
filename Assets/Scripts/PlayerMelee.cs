using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMelee : MonoBehaviour
{
    public GameObject MeleeEmitter; //calls the melee emitter game object
    public GameObject MeleeArm; //calls the melee arm game object
    public Transform _MeleeEmitter; //calls the Meleeemitter location
    public GameObject gunarm; //calls the tommyarm sprite

    public AudioSource sound; //calls the audiosource component


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("MouseMelee")) || (Input.GetButtonDown("JoystickMelee"))) //melees when leftclick or controller trigger pulled
        {
            if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on" && GameObject.Find("MeleeArm(Clone)") == null) //if sound effects are set to on
                sound.Play(); //plays the audiosource sound
            Melee();
        }
        if (GameObject.Find("MeleeArm(Clone)") == null) //if the player is not meleeing
            gunarm.gameObject.GetComponent<SpriteRenderer>().enabled = true; //turns the tommy arm visible
        else //otherwise
            gunarm.gameObject.GetComponent<SpriteRenderer>().enabled = false; //turns the tommy arm visible
    }
    void Melee()
    {
        GameObject TemporaryMeleeHandler; //creates a game object that will act as the melee arm    
        TemporaryMeleeHandler = Instantiate(MeleeArm,MeleeEmitter.transform.position, MeleeEmitter.transform.rotation) as GameObject;
        TemporaryMeleeHandler.transform.SetParent(_MeleeEmitter); //sets the melee arm as the child of the melee emitter, so that it stays on the arm
        Destroy(TemporaryMeleeHandler, 0.25f); //destroys the arm after trigger let go, so that it doesn't permanently stay there
    }
}
