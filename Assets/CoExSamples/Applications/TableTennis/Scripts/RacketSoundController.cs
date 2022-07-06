using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TableTennis
{
    public class RacketSoundController : MonoBehaviour, SoundEffectManager.IPlayable
    {
        [SerializeField] private AudioSource _audioSource;
        
        public void PlaySoundEffect()
        {
            _audioSource.Play();
        }

    }
}
