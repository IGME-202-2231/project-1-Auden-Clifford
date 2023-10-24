using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // when the player is instantiated, it should add itself to the player field
        //GameManager.Instance.Player = gameObject;
    }

    [SerializeField] private PhysicsObject playerControlledObject;
    [SerializeField] private float accelSpeed;
    private Vector2 direction;
    //[SerializeField] private MovementController playerControlledObject;
    [SerializeField] private TargetFire playerWeapon;
    
    // The method that gets called to handle any player movement input
    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the latest value for the input from the Input 
        // System and send that new direction to the Vehicle class
        //playerControlledObject.Direction = context.ReadValue<Vector2>();

        direction = context.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        // only fire when the button is first pressed
        if (context.started)
        {
            playerWeapon.Fire();
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentState == GameState.Gameplay)
        {
            playerControlledObject.ApplyForce(direction * accelSpeed);

            playerWeapon.Direction = new Vector3(
                (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).x, 
                (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).y, 0);
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            // when the player is destroyed (they die) set the game state to GameOver\
            GameManager.Instance.GameOver();
        }
    }
}
