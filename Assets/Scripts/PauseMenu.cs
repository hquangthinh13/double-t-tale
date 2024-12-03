using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private bool isPaused = false; 
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if (isPaused)Resume();
            else
            {
                Pause();
            }
        } 
    } 
    public void Resume() 
    { 
        audioManager.PlaySFX(audioManager.click);
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false; 
    } 
    void Pause() 
    { 
        audioManager.PlaySFX(audioManager.click);
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true; 
    }
    public void Home()
    {
        audioManager.PlaySFX(audioManager.home);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
