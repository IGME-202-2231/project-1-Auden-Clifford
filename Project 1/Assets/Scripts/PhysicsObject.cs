using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;

    private float mass;

    private float maxSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        // get the object's starting postion
        position = transform.position;

        mass = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // calculate velocity for this frame
        velocity += acceleration * Time.deltaTime;

        // apply friction from ground
        ApplyFriction();

        // validate the speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        print(velocity.magnitude);

        // set the postion
        position += velocity * Time.deltaTime;
        
        // grab direction from velocity
        direction = velocity.normalized;

        // set the object's postion to calculated position
        transform.position = position;

        // zero out acceleration
        acceleration = Vector3.zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    void ApplyFriction()
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * 20;
        ApplyForce(friction);
    }

}
