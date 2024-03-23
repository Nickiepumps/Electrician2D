using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public float interactionRange = 2f; // Define the interaction range

    private Transform player; // Reference to the player's transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= interactionRange)
        {
            // Object is within interaction range
            if (Input.GetMouseButtonDown(0))
            {
                // Perform interaction logic here (e.g., open a door, collect an item, etc.)
                Debug.Log("Object clicked! Perform interaction.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw interaction range wire sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}