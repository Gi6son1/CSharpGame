using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    Transform player; //this will hold tyhe transform component of the player
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Skin1").GetComponent<Transform>(); //the component is retrieved from the player game object
        player.transform.position = transform.position; //the player's position becomes the position of the player spawn gameobject
    }
}
