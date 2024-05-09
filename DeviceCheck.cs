using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCheck : MonoBehaviour
{
    public GameObject measurementIndicatorPrefab; // Prefab for the measurement indicator
    private GameObject currentMeasurementIndicator; // The current measurement indicator object

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("MeasurementDevice"))
            {
                // Instantiate the measurement indicator at the clicked position
                currentMeasurementIndicator = Instantiate(measurementIndicatorPrefab, hit.collider.transform.position, Quaternion.identity);
            }
        }
    }

    // Called when another collider enters this object's trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ElectricalDevice"))
        {
            ElectricalDevice device = other.GetComponent<ElectricalDevice>();

            // Check the value of the electrical device and log the result
            // public class ElectricalDevice : MonoBehaviour
            // {
            //     // Value of the device (0 or 1)
            //     // public int Value;
            // }

            if (device != null)
            {
                if (device.Value == 0)
                {
                    Debug.Log("Broken");
                }
                else if (device.Value == 1)
                {
                    Debug.Log("Normal");
                }
            }
        }
    }
}
