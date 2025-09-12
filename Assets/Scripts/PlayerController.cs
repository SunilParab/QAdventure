using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int moveSpeed;
    [SerializeField]
    int jumpForce;


    //Components
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveValue = 0;
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            moveValue -= 1;
        }
        if (Input.GetKey(KeyCode.RightAlt))
        {
            moveValue += 1;
        }

        rb.AddForce(Vector2.right * moveValue * moveSpeed, ForceMode2D.Force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Math.Abs(rb.linearVelocityX) > 10)
        {
            if (rb.linearVelocityX > 0) {
                rb.linearVelocityX = 10;
            } else {
                rb.linearVelocityX = -10;
            }
        }

    }
}
