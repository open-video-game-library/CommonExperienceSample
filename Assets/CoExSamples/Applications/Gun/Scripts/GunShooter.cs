using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunGame
{
    public class GunShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _muzzle;

        private const string _targetTag = "Target";

        [SerializeField] private AudioSource _shootSound;

        [SerializeField] private AudioSource _hitTargetSound;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.A)) //OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || 
            {
                Fire();
            }
        }

        private void Fire()
        {
            _shootSound.Play();
            RaycastHit hit;
            if (Physics.Raycast(_muzzle.transform.position, _muzzle.transform.forward, out hit, 1000))
            {
                Debug.DrawRay(_muzzle.transform.position, _muzzle.transform.forward * 1000, Color.blue);
                if (hit.collider.CompareTag(_targetTag))
                {
                    Hit();
                }
            }
        }

        private void Hit()
        {
            _hitTargetSound.Play();
            Debug.Log("hit");
        }
    }
}