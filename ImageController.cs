using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite[] images; // Array ���ٻ�Ҿ
    public Image displayImage; // ����ʴ��ٻ�Ҿ
    public Button nextButton; // ��������¹�ٻ�Ѵ�
    public Button prevButton; // ������͹��Ѻ

    private int currentIndex = 0; // �Ѫ�ջѨ�غѹ� array

    void Start()
    {
        // ��ҹ�����š������ٻ�Ҿ����ش
        currentIndex = PlayerPrefs.GetInt("LastEditedImageIndex", 0);

        // ��˹��ѧ��ѹ�������Ǣ�ͧ�Ѻ����
        nextButton.onClick.AddListener(NextImage);
        prevButton.onClick.AddListener(PreviousImage);
        displayImage.sprite = images[currentIndex]; // �ʴ��ٻ�Ҿ
    }

    void NextImage()
    {
        // ����͹�Ѫ��价���ٻ�Ҿ�Ѵ�
        currentIndex = (currentIndex + 1) % images.Length;
        displayImage.sprite = images[currentIndex]; // �ʴ��ٻ�Ҿ����
        SaveEditedImageIndex(); // �ѹ�֡������
    }

    void PreviousImage()
    {
        // ����͹�Ѫ�ա�Ѻ价���ٻ�Ҿ��͹˹��
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = images.Length - 1;
        }
        displayImage.sprite = images[currentIndex]; // �ʴ��ٻ�Ҿ����
        SaveEditedImageIndex(); // �ѹ�֡������
    }

    void SaveEditedImageIndex()
    {
        // �ѹ�֡�Ѫ�բͧ�ٻ�Ҿ����������ش
        PlayerPrefs.SetInt("LastEditedImageIndex", currentIndex);
        PlayerPrefs.Save(); // �ѹ�֡������
    }
}