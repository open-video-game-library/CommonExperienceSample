using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    public class ArrowManager : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowPrefab;

        private GameObject _arrowInstance;

        [SerializeField] private float _standardArrowForce;
        
        /// <summary>
        /// Assign to this variable the tension obtained from the user's movements, etc. By default, the distance between the left and right controllers is assigned.
        /// ユーザの動きなどから取得した張力をこの変数に割り当ててください.標準では左右のコントローラ間の距離を割り当てています。
        /// </summary>
        [Range(0,2)]
        public float _tension;
        
        
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
#elif UNITY_ANDROID
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                InstantiateArrow();
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

        private float CalculateTension()
        {
            
            return _tension;
        }
    }
}