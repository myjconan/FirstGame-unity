using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Interact") || Interact.InteractBtn.GetInteractBtn())
        {
            if (gameObject.name.Contains("ExitDialog"))
            {
                SoundManager.SoundManagerPack.AudioSource_BGM.enabled = false;
                GameObject.Find("Player").SetActive(false);
                SoundManager.SoundManagerPack.DoorAudio_Play();
                Invoke("LoadLastScene", 1.7f);
                
            }
            else if (gameObject.name.Contains("EnterDialog"))
            {
                SoundManager.SoundManagerPack.AudioSource_BGM.enabled = false;
                GameObject.Find("Player").SetActive(false);
                SoundManager.SoundManagerPack.DoorAudio_Play();
                Invoke("LoadNextScene", 1.7f);
            }

        }
    }
    private void LoadLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}