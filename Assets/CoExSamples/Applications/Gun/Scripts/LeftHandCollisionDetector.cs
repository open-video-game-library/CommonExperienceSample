using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GunGame
{
    public class LeftHandCollisionDetector : MonoBehaviour
    {
        [SerializeField] private GunShooter _gunShooter;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Gun"))
            {
                _gunShooter.GrabHand = OVRInput.Controller.LTouch;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Gun"))
            {
                _gunShooter.GrabHand = OVRInput.Controller.None;
            }
        }
    }
}

