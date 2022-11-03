using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    public class StringManager : MonoBehaviour
    {
        [SerializeField] private ArrowManager _arrowManager;

        private Vector3 _initialStringPosition;


        private void Start()
        {
            _initialStringPosition = new Vector3(0, -0.028385f, 0);
        }


        // Update is called once per frame
        private void Update()
        {
            if (_arrowManager.DrawBowHand == OVRInput.Controller.RTouch)
            {
                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    transform.position = _arrowManager.ArrowInstance.transform.Find("EndPoint").transform.position;
                }
            
            
                if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
                {
                    transform.localPosition = _initialStringPosition;
                }
            }
            else if (_arrowManager.DrawBowHand == OVRInput.Controller.LTouch)
            {
                if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
                {
                    transform.position = _arrowManager.ArrowInstance.transform.Find("EndPoint").transform.position;
                }
            
            
                if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
                {
                    transform.localPosition = _initialStringPosition;
                }
            }
            
        }
        
    }
}