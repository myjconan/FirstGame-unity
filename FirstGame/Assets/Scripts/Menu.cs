using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Tooltip("GameStartScene")]
    public GameObject GameStartAnimationHiddenButton1;
    public GameObject GameStartAnimationHiddenButton2;
    public GameObject StartGameButton;
    public GameObject QuitGameButton;
    [Space]
    [Tooltip("GameUI")]
    public GameObject PauseButton;
    public GameObject JoyStick;
    [Space]
    [Tooltip("PauseMenu")]
    public GameObject PauseMenu;
    public GameObject QuitButton;
    public GameObject ResumeButton;
    [Space]
    [Tooltip("AudioControl")]
    public AudioMixer MainAudio;
    public Slider MainVolumeSlider;
    public Toggle MainVolumeMute;
    private float CurrentVolume;
    [Space]
    [Tooltip("JoyStick")]
    public Button InteractBtn,JumpBtn;
    public bool IsInteractBtnPressed, IsJumpBtnPressed;

    //GameStartScene
    public void ButtonEndStartAnimation()
    {
        Destroy(GameStartAnimationHiddenButton1.gameObject);
        Destroy(GameStartAnimationHiddenButton2.gameObject);
        StartGameButton.SetActive(true);
        QuitGameButton.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //GameUI
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        JoyStick.SetActive(false);
        
    }
    //PauseMenu
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        JoyStick.SetActive(true);
    }
    public void QuitInGame()
    {

    }
    //AudioControl
    public void SetAudioVolume()
    {
        MainAudio.SetFloat("MainVolume",MainVolumeSlider.value);
    }
    public void SetAudioMute()
    {
        if (MainVolumeMute.isOn)
        {
            MainAudio.GetFloat("MainVolume", out CurrentVolume);
            MainAudio.SetFloat("MainVolume", -80f);
        }
        else
        {
            MainAudio.SetFloat("MainVolume",CurrentVolume);
        }
    }
}
