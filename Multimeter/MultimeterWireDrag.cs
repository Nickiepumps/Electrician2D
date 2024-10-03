using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultimeterWireDrag : MonoBehaviour
{
    [Header("Wire Object")]
    public GameObject wirePositive = null;
    public GameObject wireNegative = null;

    [Header("Port Position Offset")]
    [SerializeField] private float offsetX; // Pivot pos of the wire
    [SerializeField] private float offsetY; // Pivot pos of the wire

    private GameObject multimeter;
    private float wireAttachWidth;
    private float wireAttachAngle;

    private void Awake()
    {
        multimeter = GameObject.FindGameObjectWithTag("Multimeter");
    }
    private void Update()
    {
        if (multimeter.GetComponent<InstrumentManager>().positivePortClicked == true && multimeter.GetComponent<InstrumentManager>().positiveChecked == false
            && wirePositive != null)
        {
            wirePositive.SetActive(true);
            DragWire(wirePositive);
            if (multimeter.GetComponent<InstrumentManager>().positiveChecked == true)
            {
                AttachWire(wirePositive);
            }
        }
        else if(multimeter.GetComponent<InstrumentManager>().negativePortClicked == true && multimeter.GetComponent<InstrumentManager>().negativeChecked == false
            && wireNegative != null)
        {
            wireNegative.SetActive(true);
            DragWire(wireNegative);
            if (multimeter.GetComponent<InstrumentManager>().negativeChecked == true)
            {
                AttachWire(wireNegative);
            }
        }
        else if (multimeter.GetComponent<InstrumentManager>().positivePortClicked == false && wirePositive != null)
        {
            wirePositive.SetActive(false);
        }
        else if (multimeter.GetComponent<InstrumentManager>().negativePortClicked == false && wireNegative != null)
        {
            wireNegative.SetActive(false);
        }
    }
    public void DragWire(GameObject wire)
    {
        // Calculate the angle of the object by using Mouse Position
        Vector3 pos = Input.mousePosition - Camera.main.WorldToScreenPoint(wire.transform.position);
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        wireAttachAngle = angle;
        wire.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Calculate Width of the object by using Mouse Position
        //float totalWidth = ((Input.mousePosition.x - offsetX) * (Input.mousePosition.x - offsetX)) + ((Input.mousePosition.y - offsetY) * (Input.mousePosition.y - offsetY));
        Vector2 offset = new Vector2(offsetX, offsetY);
        float width = Vector2.Distance(Input.mousePosition, offset);
        wireAttachWidth = width;
        wire.GetComponent<RectTransform>().sizeDelta = new Vector2(width, wire.GetComponent<RectTransform>().sizeDelta.y);
    }
    public void AttachWire(GameObject wire)
    {
        wire.transform.rotation = Quaternion.AngleAxis(wireAttachAngle, Vector3.forward);
        wire.GetComponent<RectTransform>().sizeDelta = new Vector2(wireAttachWidth, wire.GetComponent<RectTransform>().sizeDelta.y);
    }
}
