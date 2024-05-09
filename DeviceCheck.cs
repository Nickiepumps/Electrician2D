using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCheck : MonoBehaviour
{
    public GameObject measurementIndicatorPrefab; // โมเดลของตัวเครื่องวัด
    private GameObject currentMeasurementIndicator; // ตัวเครื่องวัดที่ถูกสร้างขึ้น

    // ทำการตรวจจับการคลิกเมาส์
    void Update()
    {
        // ตรวจสอบว่ามีการคลิกที่ตัวเครื่องวัดหรือไม่
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("MeasurementDevice"))
            {
                // สร้างตัวเครื่องวัดที่ถูกกดมาแสดงบนเมาส์
                currentMeasurementIndicator = Instantiate(measurementIndicatorPrefab, hit.collider.transform.position, Quaternion.identity);
            }
        }
    }

    // ตรวจสอบค่าของช่องวัดของอุปกรณ์อิเล็ก
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ElectricalDevice"))
        {
            ElectricalDevice device = other.GetComponent<ElectricalDevice>();

            //เอาไว้เสร้างคลาสสำหรับอุปกรณ์อิเล็กทริก
            //public class ElectricalDevice : MonoBehaviour
            // {
            // ค่าของอุปกรณ์ (0 หรือ 1)
            // public int Value;
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