using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
  
    // Update is called once per frame
    void Update()
    {
        // update ONLY the camera's X and Y to the player's position
        this.transform.position = new Vector3(
                player.transform.position.x, 
                player.transform.position.y, 
                this.transform.position.z); // preserve the z value
    }
}
