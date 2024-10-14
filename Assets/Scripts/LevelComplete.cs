using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject completePanel;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("BossBody") == null) //if the boss is dead
        {
            StartCoroutine(Wait()); //start wait function
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f); //wait for 1 second
        completePanel.SetActive(true); //make the complete level panel appear
    }
}
