using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] ObjectInfo objectInfo;

    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;

    private float maxSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        // get the object's starting postion
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // apply friction from ground
        ApplyFriction();

        // calculate velocity for this frame
        velocity += acceleration * Time.deltaTime;

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

    /// <summary>
    /// Applies a force vector to this object factoring in the object's mass
    /// </summary>
    /// <param name="force">Force vector applied</param>
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / objectInfo.Mass;
    }

    /// <summary>
    /// Applies a force in the opposite direction of the spinner's velocity
    /// </summary>
    private void ApplyFriction()
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * 1.5f;
        ApplyForce(friction);
    }

    /// <summary>
    /// Resolves all collisions detected this frame
    /// </summary>
    /// <param name="collisions">List of objects being collided with</param>
    private void ResolveCollisions(List<ObjectInfo> collisions)
    {

    }
}
