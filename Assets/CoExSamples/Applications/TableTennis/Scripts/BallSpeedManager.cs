using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TableTennis
{
    public class BallSpeedManager : MonoBehaviour
    {
        OVRInput.Controller LeftCon;
        OVRInput.Controller RightCon;
        
        private string _racketTag = "Racket";

        private Rigidbody _ballRigidbody;

        [SerializeField] private float _force;
        
        void Start()
        {
            // FPSを固定
            Application.targetFrameRate = 60; 
            
            LeftCon = OVRInput.Controller.LTouch;
            RightCon = OVRInput.Controller.RTouch;

            _ballRigidbody = this.gameObject.GetComponent<Rigidbody>();
        }

       
        private void OnCollisionEnter(Collision collision)
        {
            // ラケットと衝突時の処理
            if (collision.gameObject.CompareTag(_racketTag))
            {
                _ballRigidbody.velocity *= _force;
            }
        }

        
    }
}