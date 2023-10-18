using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PhysicsObject physicsMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        physicsMovement.ApplyForce((player.transform.position - transform.position).normalized * 15);
    }
}
