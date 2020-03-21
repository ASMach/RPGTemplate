using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class WalkingController : MonoBehaviour
{
    InputManager inputManager;

    Vector2 movementInput = Vector2.zero;
    Vector3 walkVelocity = Vector3.zero;

    [SerializeField]
    float walkSpeed = 6.0f;

    private Rigidbody rb;
    void Awake()
    {
        // Initial setup
        rb = GetComponent<Rigidbody>();

        // Setup controls
        inputManager = new InputManager();
        inputManager.Player.Walk.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnEnable()
    {
        inputManager.Enable();
    }

    public void OnDisable()
    {
        inputManager.Disable();
    }

    void ProcessInput()
    {
        // Start at zero
        walkVelocity = Vector3.zero;

        // Track horizontal and vertical inputs
        float x = 0.0f;
        float y = 0.0f;
        // Adjust x movement
        if (movementInput.x > 0.0f) { x += 1.0f; }
        else if (movementInput.x < 0.0f) { x -= 1.0f; }
        // And y movement
        if (movementInput.x > 0.0f) { y += 1.0f; }
        else if (movementInput.y < 0.0f) { y -= 1.0f; }

        // Finalize movement by component
        if (x != 0) { walkVelocity += Vector3.forward * x * walkSpeed; }
        if (y != 0) { walkVelocity += Vector3.right * y * walkSpeed; }

        if (movementInput == Vector2.zero) { walkVelocity = Vector3.zero; }

        rb.velocity = new Vector3(walkVelocity.x, walkVelocity.y, walkVelocity.z);
    }
    void FixedUpdate()
    {
        ProcessInput();
    }
}
