using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player; //will hold the transform component of the plplayer
    public float smoothSpeed; //will determine how "smooth" the camera movement is
    public Vector3 cameraOffset; //will hold the desired camera distance from the player
    public Vector3 minCamPosition; //this will hold the lowest desired camera position (i set it to x = -20, y = -23)
    public Vector3 maxCamPosition; //this will hold the lowest desired camera position (i set it to x = 23, y = 23)

    // LateUpdate is called once per frame, but after the update function (preventing potential errors with player position and camera position being calculated at the same time
    void LateUpdate()
    {
        Vector3 cameraPosition = Vector3.Lerp(transform.position, player.position + cameraOffset, smoothSpeed * Time.deltaTime); //creates vector that allows smooth movement from camera to player
        transform.position = cameraPosition; //the camera position becomes the vector

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPosition.x, maxCamPosition.x), //this clamps the camera's movement to between the lowest and highest x vectors
            Mathf.Clamp(transform.position.y, minCamPosition.y, maxCamPosition.y), //this clamps the camera's movement to between the lowest and highest y vectors
            Mathf.Clamp(transform.position.z, minCamPosition.z, maxCamPosition.z)); //this clamps the camera's movement to between the lowest and highest z vectors
    }
}
