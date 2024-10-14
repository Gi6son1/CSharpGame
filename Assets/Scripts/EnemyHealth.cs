using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health; //this will hold the enemy's health and will change depending on what enemy the script is assigned to
    public GameObject enemy; //calling the enemy gameobject
    bool isDead;

    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead) //if health is 0 or less
        {
            if (GameObject.Find("SoundFX").GetComponent<Text>().text == "on") //if sound effects are set to on
            {
                isDead = true;
                sound.Play();
                enemy.transform.position = Vector3.one * 9999999f;
            }
            Destroy(enemy, 1.2f); //deletes enemy from scene
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //function called when trigger collides with enemy
    {
        if (collision.transform.gameObject.tag.Equals("PlayerBullet")) //if object is bullet
        {
            health = health - 10; //health goes down by 10
            Destroy(collision.gameObject); //destroy bullet
        }
        if (collision.transform.gameObject.tag.Equals("PlayerMelee")) //if object is player melee
        {
            health = health - 15; //health goes down by 15
        }
    }
}
