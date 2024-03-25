using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterDialog;
    public Animator Anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.SoundManagerPack.DialogAudio_Play();
            Anim.SetBool("OpenDialog", true);
            enterDialog.SetActive(true);
        }
        
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anim.SetBool("OpenDialog", false);
            Invoke("ExitDialog", 1f);
        }

    }
    private void ExitDialog()
    {
        enterDialog.SetActive(false);
    }
}
