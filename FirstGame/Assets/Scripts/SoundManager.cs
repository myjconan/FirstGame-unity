using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundManagerPack;
    [Tooltip("AudioSource")]
    public AudioSource AudioSource_BGM;
    public AudioSource AudioSource_Player;
    public AudioSource AudioSource_Enemy;
    public AudioSource AudioSource_Collection;
    public AudioSource AudioSource_Environment;
    [Space]
    [Tooltip("BGM")]
    public AudioClip BGM00;
    public AudioClip BGM01;
    public AudioClip BGM02;
    [Space]
    [Tooltip("Player")]
    public AudioClip JumpAudio;
    public AudioClip HurtAudio;
    public AudioClip FallToDeathAudio;
    public AudioClip GameOverAudio;
    [Space]
    [Tooltip("Enemy")]
    public AudioClip EnemyDeadAudio;
    [Space]
    [Tooltip("Collection")]
    public AudioClip CherryAudio;
    public AudioClip GemAudio;
    [Space]
    [Tooltip("Environment")]
    public AudioClip DialogAudio;
    public AudioClip DoorAudio;

    private void Awake()
    {
        SoundManagerPack = this;
    }
    private void Start()
    {
        Scene_BGM_Play();
    }

    //BGM
    public void Scene_BGM_Play()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameStartMenu":
                AudioSource_BGM.clip = BGM00;
                break;
            case "Scene1":
                AudioSource_BGM.clip = BGM01;
                break;
            case "Scene2":
                AudioSource_BGM.clip = BGM02;
                break;
        }
        AudioSource_BGM.Play();
    }
    //Player
    public void JumpAudio_Play()
    {
        AudioSource_Player.clip=JumpAudio;
        AudioSource_Player.Play();
    }
    public void HurtAudio_Play()
    {
        AudioSource_Player.clip = HurtAudio;
        AudioSource_Player.Play();
    }
    public void FallToDeathAudio_Play()
    {
        AudioSource_Player.clip = FallToDeathAudio;
        AudioSource_Player.Play();
    }
    public void GameOverAudio_Play()
    {
        AudioSource_Player.clip = GameOverAudio;
        AudioSource_Player.Play();
    }
    //Enemy
    public void EnemyDeadAudio_Play()
    {
        AudioSource_Enemy.clip = EnemyDeadAudio;
        AudioSource_Enemy.Play();
    }
    //Collection
    public void CherryAudio_Play()
    {
        AudioSource_Collection.clip = CherryAudio;
        AudioSource_Collection.Play();
    }
    public void GemAudio_Play()
    {
        AudioSource_Collection.clip = GemAudio;
        AudioSource_Collection.Play();
    }
    //Environment;
    public void DialogAudio_Play()
    {
        AudioSource_Environment.clip = DialogAudio;
        AudioSource_Environment.Play();
    }
    public void DoorAudio_Play()
    {
        AudioSource_Environment.clip = DoorAudio;
        AudioSource_Environment.Play();
    }
}
