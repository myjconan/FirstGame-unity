using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    public Vector3 CurrentPosition;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Death()
    {
        Destroy(rb);
        GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("death");
        SoundManager.SoundManagerPack.EnemyDeadAudio_Play();
    }
    private void Death_Destroy()
    {
        Destroy(gameObject);
    }
}
