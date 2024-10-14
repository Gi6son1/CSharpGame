using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printaccount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.Find("Selected Account").GetComponent<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
