using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    [SerializeField] private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    private float speed = 20;

    /// <summary>
    /// Gets or sets the direction of movement (normalized)
    /// </summary>
    internal Vector3 Direction
    {
        get { return direction; }
        set
        {
            // direction should only have an x and y value, no z value
            direction = new Vector2(value.x, value.y).normalized;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Grab the GameObject’s starting position
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = direction * speed * Time.deltaTime;

        // add velocity to position
        position += direction * speed * Time.deltaTime;

        transform.position = position;

        // change rotation to face direction
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
