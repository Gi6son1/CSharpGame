using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public void Destroy()
    {
        Destroy(GameObject.Find("Skin1"));
    }

}
