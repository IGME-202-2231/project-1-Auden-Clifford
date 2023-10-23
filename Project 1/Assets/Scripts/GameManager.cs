using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMesh playerRotation;
    [SerializeField] private TextMesh playerSpeed;
    [SerializeField] private TextMesh scoreDisplay;
    [SerializeField] private TextMesh roundDisplay;
    [SerializeField] private TextMesh EnemiesDisplay;

    private GameObject player;
    private List<GameObject> enemies;

    /// <summary>
    /// Gets or sets the game object that the player controls
    /// </summary>
    public GameObject Player { get { return player; } set { player = value; } }

    /// <summary>
    /// Gets a list of each enemy in the game
    /// </summary>
    public List<GameObject> Enemies { get { return enemies; } }

    // Update is called once per frame
    void Update()
    {
        playerRotation.text = "Rotation Speed: " + player.GetComponent<PhysicsObject>().AngularVelocity;
        playerSpeed.text = "Speed: " + player.GetComponent<PhysicsObject>().Velocity.magnitude;
    }
}
