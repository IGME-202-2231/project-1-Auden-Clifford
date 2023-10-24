using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFire : MonoBehaviour
{
    [SerializeField] private GameObject ammunition;
    [SerializeField] private float fireTime = 2;
    [SerializeField] private GameObject barrelSprite;

    private Vector3 direction;

    /// <summary>
    /// Gets or sets the aim direction
    /// </summary>
    internal Vector3 Direction 
    { 
        get { return direction; }
        set { direction = value.normalized; }
    }

    //[SerializeField] private MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barrelSprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    internal void Fire()
    {
        GameObject bullet = Instantiate(ammunition, transform.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Direction = direction;

        //assign this bullet's originator to this object
        bullet.GetComponent<Bullet>().Originator = this.GetComponent<ObjectInfo>();
    }
}
