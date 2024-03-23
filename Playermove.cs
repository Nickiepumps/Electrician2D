using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    public Sprite playerFront, playerBack, playerLeft, playerRight; // PlayerSprite 
    [SerializeField] private float movespeed;
    private float moveH, moveV;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * movespeed;
        moveV = Input.GetAxisRaw("Vertical") * movespeed;
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = playerBack;
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            GetComponent<SpriteRenderer>().sprite = playerFront;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (moveH, moveV);
    }
}
