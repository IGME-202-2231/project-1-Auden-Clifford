using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private MovementController playerControlledObject;

    
    // The method that gets called to handle any player movement input
    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the latest value for the input from the Input 
        // System and send that new direction to the Vehicle class
        playerControlledObject.Direction = context.ReadValue<Vector2>();
    }
    
}
