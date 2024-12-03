using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void StartGame()
    {
        audioManager.PlaySFX(audioManager.start);
        SceneManager.LoadScene("CharacterSelection");
    }
    public void PlayGame()
    {
        audioManager.PlaySFX(audioManager.start);
        SceneManager.LoadScene("Double-T-Tale");
    }
    public void Home()
    {
        audioManager.PlaySFX(audioManager.home);
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        audioManager.PlaySFX(audioManager.exit);
        Application.Quit();
    }
    
}
