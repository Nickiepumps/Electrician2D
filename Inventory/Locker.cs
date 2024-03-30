using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    // Temporary Script
    // TO DO: Make a flexible Clickable Object that can be use with different Objects
    public GameObject lockerInventory;
    public float interactionRange = 2f; // Define the interaction range
    public Transform player; // Reference to the player's transform
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object
    }
    private void OnMouseDown() // Click on the Object
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= interactionRange)
        {
            // Perform interaction logic here (e.g., open a door, collect an item, etc.)
            lockerInventory.SetActive(true);
        }
    }
    public void CloseInventory()
    {
        lockerInventory.SetActive(false);
    }
    void OnDrawGizmosSelected()
    {
        // Draw interaction range wire sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
