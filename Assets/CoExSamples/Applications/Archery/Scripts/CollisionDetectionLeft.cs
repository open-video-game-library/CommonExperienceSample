using System;
using System.Collections;
using System.Collections.Generic;
using Archery;
using TMPro;
using UnityEngine;

namespace Archery
{
    public class CollisionDetectionLeft : MonoBehaviour
    {
        [SerializeField] private ArrowManager _arrowManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bow"))
            {
                // Assign the right hand to the hand that draws the arrow because the bow is held in the left hand.
                _arrowManager.DrawBowHand = OVRInput.Controller.RTouch;
            }
        }

    }
}
