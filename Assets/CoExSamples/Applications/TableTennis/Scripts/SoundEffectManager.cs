using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TableTennis
{
    public class SoundEffectManager : MonoBehaviour
    {
        public interface IPlayable
        {
            void PlaySoundEffect();
        }
        
    
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<IPlayable>() != null)
            {
                collision.gameObject.GetComponent<IPlayable>().PlaySoundEffect();
            }
        }
    }
}

