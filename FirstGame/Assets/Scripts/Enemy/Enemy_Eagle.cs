using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Eagle : Enemy
{
    public Transform toppoint;
    public Transform bottompoint;
    public float speed;
    private float topy;
    private float bottomy;
    public Transform player;
    private bool IsDown;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        topy = toppoint.position.y;
        bottomy = bottompoint.position.y;
        Destroy(toppoint.gameObject);
        Destroy(bottompoint.gameObject);
        IsDown = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            Movement();
        }
    }
    void Movement()
    {
        if (!IsDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > topy)
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                IsDown = true;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < bottomy)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                IsDown = false;
            }

        }
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
