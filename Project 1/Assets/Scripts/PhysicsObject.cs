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
        ResolveCollisions(objectInfo.collisions);

        // apply friction from ground
        ApplyFriction();

        // calculate velocity for this frame
        velocity += acceleration * Time.deltaTime;

        // validate the speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //print(velocity.magnitude);
        //print("calcPos: " + position.x + ", " + position.y + "\n actualPos: " + transform.position.x + ", " + transform.position.y);

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
        friction = friction * 5;
        ApplyForce(friction);
    }

    /// <summary>
    /// Resolves all collisions detected this frame
    /// </summary>
    /// <param name="collisions">List of objects being collided with</param>
    private void ResolveCollisions(List<ObjectInfo> collisions)
    {
        
        foreach(ObjectInfo otherObject in collisions)
        {
            // the point where this object contacted the other will be the difference between the objects' centers normalized and scaled to the radius of this object
            Vector3 myContactPoint = position + (otherObject.Position - position).normalized * objectInfo.Radius;

            // the point where the other object contacted this one will be the difference between the objects' centers normalized and scaled to the radius of the other object
            Vector3 otherContactPoint = otherObject.Position + (position - otherObject.Position).normalized * otherObject.Radius;

            // ensure the objcts are still intersecting (the intersect may have been eliminated by the other object)
            // this object should only be the one to move out of the intersection if it is smaller
            if(Vector3.Distance(position, otherObject.Position) < objectInfo.Radius + otherObject.Radius && objectInfo.Mass <= otherObject.Mass)
            {
                // move this object to eliminate overlap between contact points 
                position += otherContactPoint - myContactPoint;
            }

            // apply a force equal to the amount of force required to stop this object
            otherObject.physics.ApplyForce((otherObject.Position - position).normalized * velocity.magnitude * objectInfo.Mass);
        }

        //print(collisions.Count);
    }
}
