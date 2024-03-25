using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLong : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform point1;
    public Transform point2;
    public float movespeed;
    private Vector3 point11;
    private Vector3 point22;
    private bool Isuporleft;
    public LayerMask map;
    public Rigidbody2D player;
    private bool IsPlayerTouch;

    void Start()
    {
        point11 = point1.position;
        point22= point2.position;
        Destroy(point1.gameObject);
        Destroy(point2.gameObject);
        Isuporleft = true;
    }

    void Update()
    {
        Movement();
        if (IsPlayerTouch)
        {
            PlayerVelocity();
        }
    }
    void PlayerVelocity()
    {
        player.velocity = rb.velocity;
        if (Input.GetButton("Jump"))
        {
            if (Isuporleft)
            {
                player.velocity = new Vector2(rb.velocity.x, 9);
            }
            else
            {
                player.velocity = new Vector2(rb.velocity.x, 5);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerTouch = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerTouch = false;
            if (Input.GetButtonDown("Jump"))
            {
                if (Isuporleft)
                {
                    player.velocity = new Vector2(rb.velocity.x, 5 + rb.velocity.y);
                }
                else
                {
                    player.velocity = new Vector2(rb.velocity.x, 5);
                }

            }
            else
            {
                player.velocity = new Vector2(0,0);
            }
        }
    }

    void Movement()
    {
        if (rb.gameObject.name.Contains("platform-long-leftright"))
        {
            PlatformLong_leftright();
        }
        else if (rb.gameObject.name.Contains("platform-long-updown"))
        {
            PlatformLong_updown();
        }
    }
    void PlatformLong_updown()
    {
        if (Isuporleft)
        {
            rb.velocity = new Vector3(0f, movespeed, 0f);
            if (transform.position.y > point11.y || rb.IsTouchingLayers(map))
            {
                rb.velocity = new Vector3(0f, -movespeed, 0f);
                Isuporleft = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(0f, -movespeed, 0f);
            if (transform.position.y < point22.y || rb.IsTouchingLayers(map))
            {
                rb.velocity = new Vector3(0f, movespeed, 0f);
                Isuporleft = true;
            }
        }
    }
    void PlatformLong_leftright()
    {
        if (Isuporleft)
        {
            rb.velocity = new Vector3(-movespeed, 0f, 0f);
            if (transform.position.x < point11.x || rb.IsTouchingLayers(map))
            {
                rb.velocity = new Vector3(movespeed, 0f, 0f);
                Isuporleft = false;
            }
        }
        else
        {
            rb.velocity = new Vector3( movespeed, 0f, 0f);
            if (transform.position.x > point22.x || rb.IsTouchingLayers(map))
            {
                rb.velocity = new Vector3(-movespeed, 0f, 0f);
                Isuporleft = true;
            }
        }
    }
}
