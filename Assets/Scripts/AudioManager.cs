using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;
    public AudioClip death;
    public AudioClip exit;
    public AudioClip home;
    public AudioClip jump;
    public AudioClip start;
    public AudioClip click;
    public AudioClip start2;
    public AudioClip hit;
    public AudioClip[] background;
    public void Start()
    {
        int i = Random.Range(0,background.Length);
        musicSource.clip = background[i];
        musicSource.Play();
    }
    public void Update()
    {
        if (musicSource.isPlaying!=true)
        {
            int i = Random.Range(0,background.Length);
            musicSource.clip = background[i];
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
