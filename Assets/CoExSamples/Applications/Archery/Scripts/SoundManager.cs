using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource _audioSource;

        [SerializeField] private AudioClip _fire;

        [SerializeField] private AudioClip _collision;
        
        // Start is called before the first frame update
        private void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void PlayFireSound()
        {
            _audioSource.PlayOneShot(_fire);
        }

        public void PlayCollisionSound()
        {
            _audioSource.PlayOneShot(_collision);
        }

        
    }
}