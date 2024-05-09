using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCheck : MonoBehaviour
{
    public GameObject measurementIndicatorPrefab; // ���Ţͧ�������ͧ�Ѵ
    private GameObject currentMeasurementIndicator; // �������ͧ�Ѵ���١���ҧ���

    // �ӡ�õ�Ǩ�Ѻ��ä�ԡ�����
    void Update()
    {
        // ��Ǩ�ͺ����ա�ä�ԡ���������ͧ�Ѵ�������
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("MeasurementDevice"))
            {
                // ���ҧ�������ͧ�Ѵ���١�����ʴ��������
                currentMeasurementIndicator = Instantiate(measurementIndicatorPrefab, hit.collider.transform.position, Quaternion.identity);
            }
        }
    }

    // ��Ǩ�ͺ��Ңͧ��ͧ�Ѵ�ͧ�ػ�ó������
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ElectricalDevice"))
        {
            ElectricalDevice device = other.GetComponent<ElectricalDevice>();

            //����������ҧ��������Ѻ�ػ�ó�����硷�ԡ
            //public class ElectricalDevice : MonoBehaviour
            // {
            // ��Ңͧ�ػ�ó� (0 ���� 1)
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