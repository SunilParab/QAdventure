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
        if (!GameState.reference.PlayerPaused())
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
                if (IsGrounded())
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        if (Math.Abs(rb.linearVelocityX) > 10)
            {
                if (rb.linearVelocityX > 0)
                {
                    rb.linearVelocityX = 10;
                }
                else
                {
                    rb.linearVelocityX = -10;
                }
            }

    }

    public bool IsGrounded()
    {
        LayerMask jumpable = LayerMask.GetMask("Ground") | LayerMask.GetMask("Copyable");
        Collider2D floorCollider = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.25f), new Vector2(0.9f, 0.5f), 0, jumpable);

        return floorCollider != null;
    }

    public bool IsRegularGrounded()
    {
        LayerMask jumpable = LayerMask.GetMask("Ground");
        Collider2D floorCollider = Physics2D.OverlapBox(new Vector2(transform.position.x,transform.position.y-0.25f), new Vector2(0.9f,0.5f), 0, jumpable);
        
        return floorCollider != null;
    }

}
