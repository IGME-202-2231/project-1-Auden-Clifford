using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private Vector3 position;
    private Vector3 direction;
    private float speed = 5f;

    private GameObject originator;

    /// <summary>
    /// Gets or sets the originator (shooter) of this bullet
    /// </summary>
    internal GameObject Originator
    {
        get { return originator; }
        set { originator = value; }
    }

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
        // get the object's position
        position = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        

        position += direction * speed * Time.deltaTime;

        //validate

        // set the position
        transform.position = position;

        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
