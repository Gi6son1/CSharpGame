using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerGeneral : MonoBehaviour
{
    public int health = 200;  //player health set to 200
    public GameObject player; //holds player gameobject
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    public SpriteRenderer skin2; //will hold the skin2 gameobject
    public SpriteRenderer skin3; //will hold the skin3 gameobject
    bool isDead;

    public Animator animator; //calls animator component
    public AudioSource playerdeath;
    public AudioSource playerHit;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        Physics2D.IgnoreLayerCollision(11, 9); //means enemies and the player do not collide
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
    }

    // Update is called once per frame
    void Update()
    {
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (fileContents[2].Contains("1")) //if the recent skin is skin1
        {
            skin2.enabled = false;  //both skins disappear, showing the skin1 underneath
            skin3.enabled = false;
        }
        if (fileContents[2].Contains("2")) //if the recent skin is skin2
        {
            skin2.enabled = true; //skin2 is shown
            skin3.enabled = false; //skin3 disappears
            Debug.Log("2");
        }
        if (fileContents[2].Contains("3")) //if the recent skin is skin3
        {
            skin2.enabled = false;  //skin2 disappears
            skin3.enabled = true; //skin3 is shown
        }
        animator.SetInteger("SkinNum", int.Parse(fileContents[2]));
        if (health <= 0 && !isDead) //if health is 0 or less
        {
            if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if sound effects are set to on
            {
                isDead = true;
                playerdeath.Play();
                player.transform.position = Vector3.one * 999999f;
            }
            Destroy(player, 2.5f); //deletes player from scene
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //function called when trigger collides with player
    {
        if (collision.transform.gameObject.tag.Equals("enemy attack")) //if object is enemy bullet
        {
            if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if sound effects are set to on
                playerHit.Play();
            health = health - 5; //health goes down by 10
            Destroy(collision.gameObject); //destroy bullet
        }
        if (collision.transform.gameObject.tag.Equals("wolf attack")) //if object is enemy2
        {
            if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if sound effects are set to on
                playerHit.Play();
            health = health - 10; //health goes down by 10
        }
        if (collision.transform.gameObject.tag.Equals("Boss Attack")) //if object is boss bullet
        {
            if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if sound effects are set to on
                playerHit.Play();
            health = health - 20; //health goes down by 20
            Destroy(collision.gameObject); //destroy bullet
        }
    }
}
