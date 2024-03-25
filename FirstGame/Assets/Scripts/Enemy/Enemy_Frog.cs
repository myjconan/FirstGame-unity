using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : Enemy
{

    public Transform leftpoint;
    public Transform rightpoint;
    private float leftx;
    private float rightx;
    public float speed;
    public float jumpforce;
    public LayerMask ground;
    public Collider2D coll_circle;
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
            SwitchAnim();
        }
    }
    void Movement()
    {

            if (transform.localScale.x == 1)
            {
                rb.velocity = new Vector2(-speed, jumpforce);
                if (rb.position.x < leftx)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    rb.velocity = new Vector2(speed, jumpforce);
                }
            }
            else
            {
                rb.velocity = new Vector2(speed, jumpforce);
                if (rb.position.x > rightx)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    rb.velocity = new Vector2(-speed, jumpforce);
                }
            }

    }
    void SwitchAnim()
    {

        if (rb.velocity.y > 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("jumping", true);
            anim.SetBool("falling", false);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
            anim.SetBool("idle", false);
        }
        if (coll_circle.IsTouchingLayers(ground))
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }
}