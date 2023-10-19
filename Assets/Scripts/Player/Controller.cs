using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [Header("Movement Variables")]
    [Tooltip("The speed at which the player will move.")]
    public float moveSpeed = 10.0f;
    [Tooltip("The speed at which the player rotates in asteroids movement mode")]
    public float rotationSpeed = 60f;
    
    [Header("Input Actions & Controls")]
    [Tooltip("The input action(s) that map to player movement")]
    public InputAction moveAction;
    [Tooltip("The input action(s) that map to where the controller looks")]
    public InputAction lookAction;

    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (moveAction.bindings.Count == 0 || lookAction.bindings.Count == 0)
        {
            Debug.LogWarning("An Input Action does not have a binding set! Make sure that each Input Action has a binding set or the controller will not work!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Vector2 lookPosition = GetLookPosition();
        if (moveAction.bindings.Count == 0)
        {
            Debug.LogError("The Move Input Action does not have a binding set! It must have a binding set in order for movement to happen!");
        }

        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float hMovement = moveInput.x;
        float vMovement = moveInput.y;
        Vector3 movementVector = new Vector3(hMovement, vMovement, 0);
        MovePlayer(movementVector);
        LookAtPoint(lookPosition);
    }

    private Vector2 GetLookPosition()
    {
        Vector2 result = transform.up;
        if (lookAction.bindings.Count == 0)
        {
            Debug.LogError("The Look Input Action does not have a binding set! It must have a binding set in order for the player to look around!");
            return result;
        }

        return lookAction.ReadValue<Vector2>();
    }

    private void MovePlayer(Vector3 movement)
    {
        transform.position = transform.position + (movement * Time.deltaTime * moveSpeed);
    }

    private void LookAtPoint(Vector3 point)
    {
        if (Time.timeScale <= 0) return;
        Vector2 lookDirection = Camera.main.ScreenToWorldPoint(point) - transform.position;
        transform.up = lookDirection;
    }
}
