using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    protected Animator anim;
    protected Collider2D col;
    //protected virtual void start()
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    public void Gotton()
    {
        GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("Gotton");
        //计分
        if (col.gameObject.name.Contains("cherry"))
        {
            //GameObject.Find("Score").GetComponent<Score>().CherryCount();
            SoundManager.SoundManagerPack.CherryAudio_Play();
            FindObjectOfType<Score>().CherryCount();
        }
        else if (col.gameObject.name.Contains("gem"))
        {
            //GameObject.Find("Score").GetComponent<Score>().GemCount();
            SoundManager.SoundManagerPack.GemAudio_Play();
            FindObjectOfType<Score>().GemCount();
        }
    }
    public void DestroyCollection()
    {
        Destroy(gameObject);
    }
}