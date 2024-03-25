using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Opossum : Enemy
{
    public Transform leftpoint;
    public Transform rightpoint;
    private float leftx;
    private float rightx;
    public float speed;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
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
        if (transform.localScale.x == 1)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (rb.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (rb.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }
}
