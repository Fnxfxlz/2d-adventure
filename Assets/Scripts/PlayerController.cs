using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputAction moveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {

       moveAction.Enable();
       rigidbody2d = GetComponent<Rigidbody2D>();

       // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 120;

    }

    // Update is called once per frame
    void Update()
    {
       // Store the moveAction values into a Vector2 variable called move
       move = moveAction.ReadValue<Vector2>();

        // Display the current Vector2 value for move in the Console
        Debug.Log(move);
       
    }


    void FixedUpdate()
    {
        // Create a variable called position and add the move value from InputAction to the current
        // Vector2 position
        Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);

    }
}
