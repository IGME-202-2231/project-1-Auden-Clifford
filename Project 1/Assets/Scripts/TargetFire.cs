using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFire : MonoBehaviour
{
    [SerializeField] private GameObject ammunition;
    //[SerializeField] private MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Fire(Vector3 direction)
    {
        GameObject bullet = Instantiate(ammunition, transform.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Direction = direction;
    }
}
