using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    float speed = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        // Grab the GameObject’s starting position
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // every update, the velocity should increase by the amount given by speed and direction
        // this creates acceleration based movement rather than linear movement
        velocity += direction * speed * Time.deltaTime;

        // apply some friction over time
        velocity *= 0.9f;

        // the magnitude of velocity will never reach 0 when friction is applied in this way
        // therefore once velocity is below 0.1f, it will jump to 0
        if(velocity.magnitude <= 0.1f)
        {
            velocity = Vector3.zero;
        }

        // add velocity to position
        objectPosition += velocity;

        // validate position (collide)

        // draw the object at the new position
        transform.position = objectPosition;
    }
}
