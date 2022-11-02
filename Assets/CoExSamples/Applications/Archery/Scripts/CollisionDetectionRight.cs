using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Archery
{
    public class CollisionDetectionRight : MonoBehaviour
    {
        [SerializeField] private ArrowManager _arrowManager;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bow"))
            {
                // Assign the left hand to the hand that draws the arrow because the bow is held in the right hand.
                _arrowManager.DrawBowHand = OVRInput.Controller.LTouch;
            }
        }
    }

}
