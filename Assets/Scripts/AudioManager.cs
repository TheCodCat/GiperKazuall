using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _tapAudioSource;
    [SerializeField] private AudioClip _tapAudioClip;

    public void TapAudio(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _tapAudioSource.clip = _tapAudioClip;
            _tapAudioSource.Play();
        }

    }
}
