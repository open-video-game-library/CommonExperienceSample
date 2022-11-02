using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Archery
{
    public class BowGrabHandDetection : MonoBehaviour
    {
        [SerializeField] private ArrowManager _arrowManager;

        [SerializeField] private TextMeshProUGUI _text;
        private void OnCollisionEnter(Collision collision)
        {
            _text.text = collision.gameObject.name;

            if (collision.gameObject.CompareTag("RightHand"))
            {
                _text.text = "right";
                //_arrowManager.CurrentHandType = Hand.Right;
            }
            else if (collision.gameObject.CompareTag("LeftHand"))
            {
                //_arrowManager.CurrentHandType = Hand.Left;
                _text.text = "left";
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _text.text = other.gameObject.name;

            if (other.gameObject.CompareTag("RightHand"))
            {
                _text.text = "right";
                //_arrowManager.CurrentHandType = Hand.Right;
            }
            else if (other.gameObject.CompareTag("LeftHand"))
            {
                //_arrowManager.CurrentHandType = Hand.Left;
                _text.text = "left";
            }
        }

        private void OnCollisionExit(Collision other)
        {
            _text.text = "OCE" + other.gameObject.name;
            //_arrowManager.DrawBowHand = Hand.InValid;
        }
    }
}

