using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    float speed = 0.01f;

    /// <summary>
    /// Gets or sets the direction of movement (normalized)
    /// </summary>
    internal Vector3 Direction
    {
        get { return direction; }
        set
        {
            direction = value.normalized;
        }
    }

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

        // apply some friction to slow down over time
        // player will lose 0.1% of velocity every second
        velocity *= 0.999f;

        // add velocity to position
        objectPosition += velocity;

        // validate position (collide)

        // draw the object at the new position
        transform.position = objectPosition;
    }

    private void OnDrawGizmos()
    {
        // draw a line for the input direction
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(objectPosition, objectPosition + (direction * 2));

        // draw a line for the velocity
        Gizmos.color = Color.green;
        Gizmos.DrawLine(objectPosition, objectPosition + (velocity * 500));
    }
}
