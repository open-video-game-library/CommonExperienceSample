using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Archery
{
    public class ArrowManager : MonoBehaviour
    {
        private bool Drawable;
        
        [SerializeField] private GameObject _arrowPrefab;

        [HideInInspector] public GameObject ArrowInstance;

        private Vector3 _initialPosition;

        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private SoundManager _soundManager;

        [SerializeField] private HapticManager _hapticManager;
        
        public OVRInput.Controller DrawBowHand;
        
        
        /// <summary>
        /// Assign to this variable the tension obtained from the user's movements, etc. By default, the distance between the left and right controllers is assigned.
        /// ユーザの動きなどから取得した張力をこの変数に割り当ててください.標準では左右のコントローラ間の距離を割り当てています。
        /// </summary>
        private  float _tension = 1;
        

        // Start is called before the first frame update
        private void Start()
        {
            // Initial arrow generation
            StartCoroutine(SetArrow());

        }

        // Update is called once per frame
        private void Update()
        {
            if (!Drawable)
            {
                if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) ||
                    OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
                {
                    Drawable = true;
                }
                return;
            }
            
            if (DrawBowHand == OVRInput.Controller.RTouch)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                { 
                    _initialPosition = transform.InverseTransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
                    return;
                }
                if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
                {
                    Drawable = true;
                    StartCoroutine(SetArrow());
                    Fire();
                    return;
                }
                
                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    Draw(DrawBowHand);
                    ReleaseDetection(DrawBowHand);
                    return;
                }
            }
            else if (DrawBowHand == OVRInput.Controller.LTouch)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
                {
                    _initialPosition = transform.InverseTransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
                    return;
                }
                if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
                {
                    Drawable = true;
                    StartCoroutine(SetArrow());
                    Fire();
                    return;
                }
                
                if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
                {
                    Draw(DrawBowHand);
                    ReleaseDetection(DrawBowHand);
                    return;
                }
            }
 
        }

            private  void Generate()
            {
                ArrowInstance = Instantiate(_arrowPrefab, gameObject.transform);
            }

            private void Draw(OVRInput.Controller Controller)
            {
                ArrowInstance.transform.localPosition = new Vector3(ArrowInstance.transform.localPosition.x,
                    ArrowInstance.transform.localPosition.y, -2 + CalculateHandDistance());
                
                // Call the method that gives tactile feedback.To change to your own feedback, rewrite the following method.
                _hapticManager.ProvideHapticFeedback(CalculateTension(), Controller);
            }

            private float CalculateHandDistance()
            {
                if (DrawBowHand == OVRInput.Controller.RTouch)
                {
                    var currentPosition =
                        transform.InverseTransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
                    return currentPosition.z - _initialPosition.z;
                }
                else
                {
                    var currentPosition =
                        transform.InverseTransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
                    return currentPosition.z - _initialPosition.z;
                }
                
            }

            private void Fire()
            {
                // play SE
                _soundManager.PlayFireSound();
                
                // Apply force to the arrow.
                Rigidbody rb = ArrowInstance.GetComponent<Rigidbody>();
                rb.useGravity = true;
                //rb.centerOfMass = 
                float force = CalculateTension();
                rb.AddForce( -transform.forward * force);

                // Unlocking the parent-child relationship between Bow and Arrow
                ArrowInstance.gameObject.transform.parent = null;
                
                // stop haptic feedback
                OVRInput.SetControllerVibration(0, 0);
            }

            
            
            /// <summary>
            /// 左右のコントローラの距離から張力を定義
            /// Tension is defined from the distance between the left and right controllers
            /// </summary>
            /// <returns></returns>
            private float CalculateTension()
            {
                Vector3 leftControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
                Vector3 rightControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
                float currentDistance = Mathf.Abs((leftControllerPosition - rightControllerPosition).magnitude) * 10;
                _tension = Mathf.Pow(currentDistance, 3) * 6;
                _text.text = _tension.ToString();
                return _tension;
            }

            
            
            private void ReleaseDetection(OVRInput.Controller Controller)
            {
                var currentPosition =
                    transform.InverseTransformPoint(OVRInput.GetLocalControllerPosition(Controller));
                float differenceX = currentPosition.x - ArrowInstance.transform.localPosition.x;
                float differenceY = currentPosition.y - ArrowInstance.transform.localPosition.y;

                float distance = Mathf.Sqrt(Mathf.Pow(differenceX, 2) + Mathf.Pow(differenceY, 2));

                if (distance > 1)
                {
                    Drawable = false;
                    ArrowInstance.transform.localPosition = new Vector3(0, 0, -2);
                    OVRInput.SetControllerVibration(0, 0);
                }
            }

            private IEnumerator SetArrow()
            {
                yield return new WaitForSeconds(0.5f);
                Generate();
            }

    }
    }
