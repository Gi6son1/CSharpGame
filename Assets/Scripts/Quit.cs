using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait()); //starts wait function
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f); //wait for 4 seconds
        Application.Quit(); //closes game
    }
}
