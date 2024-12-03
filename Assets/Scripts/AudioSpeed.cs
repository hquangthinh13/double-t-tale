using UnityEngine;

public class AudioSpeed : MonoBehaviour
{
    //public AudioSource audioSource;
    static public AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        audioManager.musicSource.pitch = 0.85f;
        audioManager.SFXSource.pitch = 0.85f;
    }
    private void Start()
    {
        audioManager.musicSource.pitch = 0.85f;
        audioManager.SFXSource.pitch = 0.85f;
    }
    private void Update()
    {
        //audioSource.pitch += 0.00001f;
        audioManager.musicSource.pitch += 0.00001f;
        audioManager.SFXSource.pitch += 0.00001f;
    }
}
