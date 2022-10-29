using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Archery
{
    public class ArrowManager : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowPrefab;

        private GameObject _arrowInstance;

        [SerializeField] private float _standardArrowForce;

        private static float _defaultDistance;
        
        /// <summary>
        /// Assign to this variable the tension obtained from the user's movements, etc. By default, the distance between the left and right controllers is assigned.
        /// ユーザの動きなどから取得した張力をこの変数に割り当ててください.標準では左右のコントローラ間の距離を割り当てています。
        /// </summary>
        [Range(0,2)]
        public float _tension = 1;

        public bool Drawable;
        // Start is called before the first frame update
        private void Start()
        {
            // Initial arrow generation
            Generate();
        }

        // Update is called once per frame
        private void Update()
        {
#if UNITY_EDITOR
            if(Input.GetMouseButtonDown(1))
            {
                Generate();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
//#elif UNITY_ANDROID
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                Generate();
            }
            
            
            if(!Drawable) return;

            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                Draw(OVRInput.Controller.RTouch);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                Draw(OVRInput.Controller.LTouch);
            }
            if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
            {
                Shoot();
            }
#endif
        }

        private void Generate()
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.17f);
            _arrowInstance = Instantiate(_arrowPrefab, pos, Quaternion.identity);
        }

        private void Shoot()
        {
            Rigidbody rb = _arrowInstance.GetComponent<Rigidbody>();
            rb.useGravity = true;
            float force = _standardArrowForce * CalculateTension();
            rb.AddForce(-transform.forward * force);
        }

        /// <summary>
        /// 左右のコントローラの距離から張力を定義
        /// Tension is defined from the distance between the left and right controllers
        /// </summary>
        /// <returns></returns>
        private float CalculateTension()
        {
#if UNITY_EDITOR
            return _tension;
#elif UNITY_ANDROID
            Vector3 leftControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            Vector3 rightControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            float currentDistance = Mathf.Abs((leftControllerPosition - rightControllerPosition).magnitude);
            _tension = currentDistance / _defaultDistance;
            return _tension;
#endif
            
        }

        private void Draw(OVRInput.Controller drawHand)
        {
            //OVRInput.GetLocalControllerPosition(drawHand) - 
        }

        

        private void OnTriggerStay(Collider other)
        {
            Drawable = true;
        }

        private void OnTriggerExit(Collider other)
        {
            Drawable = false;

        }
    }
}