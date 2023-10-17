using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // all objects need to add themselves to this therefore it must be universally available
    public static List<ObjectInfo> gameObjects = new List<ObjectInfo>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // loop through each item
        foreach(ObjectInfo collidable in gameObjects)
        {
            // before calculating new collisions, clear the old ones
            collidable.collisions.Clear();

            // check each item against each other item
            foreach(ObjectInfo otherCollidable in gameObjects)
            {
                // make sure objects are not checked against themselves
                if(collidable != otherCollidable)
                {
                    if (Vector2.Distance(collidable.Position, otherCollidable.Position) <= collidable.Radius + otherCollidable.Radius)
                    {
                        // if they're colliding, add the collision to the object's collisions list
                        collidable.collisions.Add(otherCollidable);
                    }
                }
            }
        }

        print(gameObjects.Count);
    }
}
