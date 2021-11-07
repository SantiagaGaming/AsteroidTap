using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : MonoBehaviour
{
    [SerializeField] private AudioClip _bang, _fail;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayBangSound()
    {
        _audioSource.PlayOneShot(_bang);
    }
    public void PlayFailSound()
    {
        _audioSource.PlayOneShot(_fail);
    }
}
