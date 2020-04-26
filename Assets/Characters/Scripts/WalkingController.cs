using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class WalkingController : MonoBehaviour
{
    Vector2 target;

    private NavMeshAgent agent;
    void Awake()
    {
        // Initial setup
        agent = GetComponent<NavMeshAgent>();
    }

    public void OnEnable()
    {
        agent.enabled = true;
    }

    public void OnDisable()
    {
        agent.enabled = false;
    }

    void ProcessMovement()
    {
        // Check if we have clicked or tapped somewhere to move there
        if (Input.GetMouseButtonDown(0)) // TODO: Add or for tap
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // Only go to a new location if it exists and has been set
        if (target != null)
        {
            agent.SetDestination(target);
        }
    }
    void FixedUpdate()
    {
        ProcessMovement();
    }
}
