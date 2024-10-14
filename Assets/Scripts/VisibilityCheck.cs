using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityCheck : MonoBehaviour
{
    public bool offscreen; //will determine if object is offscreen

    void Start()
    {
        offscreen = true; //set to true
    }
    private void OnBecameInvisible() //function called when object is not seen by camera
    {
        offscreen = true; //set to true
    }
    private void OnBecameVisible() //function called when object is not seen by camera
    {
        offscreen = false; //set to false
    }
}
