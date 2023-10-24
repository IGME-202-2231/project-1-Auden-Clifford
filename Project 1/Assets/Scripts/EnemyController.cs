using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float accelSpeed;
    GameObject player;
    [SerializeField] PhysicsObject physicsMovement;
    [SerializeField] int score;
    [SerializeField] RadialFire weapon;
    [SerializeField] float detectionRadius;

    // Start is called before the first frame update
    void Start()
    {
        // when an enemy is instantiated, it should add itself to the Game Manager
        GameManager.Instance.Enemies.Add(gameObject);

        // get a reference to the player
        player = GameManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentState == GameState.Gameplay)
        {
            physicsMovement.ApplyForce((player.transform.position - transform.position).normalized * accelSpeed);

            // only shoot if the player is within the detection radius
            if (Vector3.Distance(player.transform.position, transform.position) < detectionRadius)
            {
                // if this enemy has the ability to fire a weapon, do so
                if (weapon != null)
                {
                    weapon.Fire();
                }
            }
        }
    }

    private void OnDestroy()
    {
        // when an enemy is destroyed, it should be removed from the game manager
        if(GameManager.Instance != null)
        {
            GameManager.Instance.Enemies.Remove(gameObject);
            if(GameManager.Instance.currentState == GameState.Gameplay)
            {
                GameManager.Instance.Score += score;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
