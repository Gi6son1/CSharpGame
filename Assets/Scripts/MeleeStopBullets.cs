using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeStopBullets : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //called when object collides with melee
    {
        if (collision.gameObject.tag.Equals("enemy attack")) //if it is a bullet
            Destroy(collision.gameObject); //destroy bullet
    }
}
