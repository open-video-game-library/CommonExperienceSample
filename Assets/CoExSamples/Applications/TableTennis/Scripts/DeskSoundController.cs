using System.Collections;
using System.Collections.Generic;
using TableTennis;
using UnityEngine;

namespace TableTennis
{
    public class DeskSoundController : MonoBehaviour, SoundEffectManager.IPlayable
    {
        [SerializeField] private AudioSource _audioSource;

        public void PlaySoundEffect()
        {
            _audioSource.Play();
        }
    }
}