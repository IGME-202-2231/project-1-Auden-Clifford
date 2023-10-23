using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float accelSpeed;
    [SerializeField] GameObject player;
    [SerializeField] PhysicsObject physicsMovement;

    // Start is called before the first frame update
    void Start()
    {
        // when an enemy is instantiated, it should add itself to the Game Manager
        GameManager.Instance.Enemies.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        physicsMovement.ApplyForce((player.transform.position - transform.position).normalized * accelSpeed);
    }

    private void OnDestroy()
    {
        // when an enemy is destroyed, it should be removed from the game manager
        if(GameManager.Instance != null)
        {
            GameManager.Instance.Enemies.Remove(gameObject);
        }
    }
}
