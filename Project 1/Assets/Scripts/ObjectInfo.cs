using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Projectile,
    Spinner
}

public class ObjectInfo : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] public PhysicsObject physics;
    [SerializeField] private ObjectType type;
    //[SerializeField] private float mass;

    // when CollisionManager detects a collision, the object that this object collided
    // with will be sent here so that the objects can resolve the collision internally
    internal List<ObjectInfo> collisions = new List<ObjectInfo>();

    /*
    /// <summary>
    /// Gets a reference to this object's collision list
    /// </summary>
    public List<ObjectInfo> Collisions
    { get { return collisions; } }
    */

    /// <summary>
    /// Gets the object's type
    /// </summary>
    public ObjectType Type { get { return type; } }

    /// <summary>
    /// Gets the radius of the bounding circle
    /// </summary>
    public float Radius
    {
        get { return radius; }
    }

    /// <summary>
    /// Gets the mass of the object, equal to the area of the object
    /// </summary>
    public float Mass
    {
        get { /*return mass;*/ return Mathf.PI * Mathf.Pow(radius, 2); }
    }

    /// <summary>
    /// Gets or sets whether the object is currently colliding with someting
    /// </summary>
    public bool IsColliding { get; set; }

    /// <summary>
    /// Gets this object's current position
    /// </summary>
    public Vector3 Position { get { return transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        // when an object is instantiated (either mid-game or at the beginning)
        // it should add itself to the Collision Manager's object list
        CollisionManager.Instance.GameObjects.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // change the sprite color in response to collisions
        //  this is only because red gizmos do not show up in builds
        if (collisions.Count > 0)
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.white;
        }
        */
    }

    private void OnDrawGizmos()
    {
        /*
        // if there are any unresolved collisions, the gizmos should be red
        if (collisions.Count > 0)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.white;
        }

        Gizmos.DrawWireSphere(transform.position, radius);
        */
    }

    private void OnDestroy()
    {
        if(CollisionManager.Instance != null)
        {
            // when objects are destroyed they should remove themselves from the collision manager
            CollisionManager.Instance.GameObjects.Remove(this);
        }
    }
}
