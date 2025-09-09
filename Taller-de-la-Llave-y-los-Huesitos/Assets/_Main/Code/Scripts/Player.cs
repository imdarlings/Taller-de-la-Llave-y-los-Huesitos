 using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    private Rigidbody2D rb2D;

    private float move;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(Vector2.up * 300f);
        }

    }

}