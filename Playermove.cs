using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movespeed;
    private float moveH, moveV;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveH = Input.GetAxis("Horizontal") * movespeed;
        moveV = Input.GetAxis("Vertical") * movespeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (moveH, moveV);
    }
}
