using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite[] images; // Array เก็บรูปภาพ
    public Image displayImage; // ตัวแสดงรูปภาพ
    public Button nextButton; // ปุ่มเปลี่ยนรูปถัดไป
    public Button prevButton; // ปุ่มย้อนกลับ

    private int currentIndex = 0; // ดัชนีปัจจุบันใน array

    void Start()
    {
        // อ่านข้อมูลการแก้ไขรูปภาพล่าสุด
        currentIndex = PlayerPrefs.GetInt("LastEditedImageIndex", 0);

        // กำหนดฟังก์ชันที่เกี่ยวข้องกับปุ่ม
        nextButton.onClick.AddListener(NextImage);
        prevButton.onClick.AddListener(PreviousImage);
        displayImage.sprite = images[currentIndex]; // แสดงรูปภาพ
    }

    void NextImage()
    {
        // เลื่อนดัชนีไปที่รูปภาพถัดไป
        currentIndex = (currentIndex + 1) % images.Length;
        displayImage.sprite = images[currentIndex]; // แสดงรูปภาพใหม่
        SaveEditedImageIndex(); // บันทึกการแก้ไข
    }

    void PreviousImage()
    {
        // เลื่อนดัชนีกลับไปที่รูปภาพก่อนหน้า
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = images.Length - 1;
        }
        displayImage.sprite = images[currentIndex]; // แสดงรูปภาพใหม่
        SaveEditedImageIndex(); // บันทึกการแก้ไข
    }

    void SaveEditedImageIndex()
    {
        // บันทึกดัชนีของรูปภาพที่แก้ไขล่าสุด
        PlayerPrefs.SetInt("LastEditedImageIndex", currentIndex);
        PlayerPrefs.Save(); // บันทึกข้อมูล
    }
}