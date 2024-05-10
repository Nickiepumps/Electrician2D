using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MeasurementSystem : MonoBehaviour, IPointerClickHandler
{
    public GameObject measurementSpritePrefab;
    private GameObject currentMeasurementSprite;
    public ObjectiveNoteManager objectiveNoteManager; // Reference to ObjectiveNoteManager

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if this is the measurement device button
        if (eventData.pointerPress.CompareTag("MeasurementDeviceButton"))
        {
            // Instantiate measurement sprite at mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure the sprite is in the correct z position
            currentMeasurementSprite = Instantiate(measurementSpritePrefab, mousePosition, Quaternion.identity);

            // Call DisplayObjective function in ObjectiveNoteManager
            objectiveNoteManager.DisplayObjective(currentMeasurementSprite);
        }
        // Check if this is the electrical device button
        else if (eventData.pointerPress.CompareTag("ElectricalDeviceButton"))
        {
            // Perform checking of electrical device value
            ElectricalDevice device = eventData.pointerPress.GetComponentInParent<ElectricalDevice>();
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
