using UnityEngine;

public class AudioSpeed : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
    private void Start()
        {
            audioSource.pitch = 0.85f;
        }
    private void Update()
        {
            audioSource.pitch += 0.00001f;
        }
}
