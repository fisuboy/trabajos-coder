using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject confirmMenu;
    [SerializeField] private GameObject confirmQuit;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private IguanaAttack iguanaAttack;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private int scene;
    public static bool gameIsPause = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        iguanaAttack.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    private void Pause()
    {
        iguanaAttack.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void Menu()
    {
        confirmMenu.SetActive(true);
    }

    public void QuitGame()
    {
        confirmQuit.SetActive(true);
    }

    public void ConfirmMenu()
    {
        SceneManager.LoadScene(scene);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void CancelConfirm()
    {
        confirmMenu.SetActive(false);
        confirmQuit.SetActive(false);
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void QuitOptionMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void LowQualityToggle(bool toggle)
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void MediumQualityToggle(bool toggle)
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void HighQualityToggle(bool toggle)
    {
        QualitySettings.SetQualityLevel(2);
    }
}
