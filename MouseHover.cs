using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject outlineObject;
    public Color outlineColor = Color.yellow;
    public float outlineThickness = 0.1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // สร้างวัตถุใหม่สำหรับเส้นขอบ
            outlineObject = new GameObject("Outline");
            outlineObject.transform.SetParent(transform);
            outlineObject.transform.localPosition = Vector3.zero;
            outlineObject.transform.localScale = Vector3.one * (1 + outlineThickness);

            // เพิ่ม SpriteRenderer ให้กับวัตถุเส้นขอบ
            SpriteRenderer outlineSpriteRenderer = outlineObject.AddComponent<SpriteRenderer>();
            outlineSpriteRenderer.sprite = spriteRenderer.sprite;
            outlineSpriteRenderer.color = outlineColor;
            outlineSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 1; // ทำให้เส้นขอบอยู่ข้างหลังวัตถุหลัก
            outlineObject.SetActive(false); // ซ่อนเส้นขอบไว้ก่อน
        }
    }

    void OnMouseEnter()
    {
        if (outlineObject != null)
        {
            outlineObject.SetActive(true); // แสดงเส้นขอบเมื่อเมาส์เข้าใกล้
        }
    }

    void OnMouseExit()
    {
        if (outlineObject != null)
        {
            outlineObject.SetActive(false); // ซ่อนเส้นขอบเมื่อเมาส์ออกห่าง
        }
    }
}