using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunGame
{
    public class TargetSlider : MonoBehaviour
    {
        [SerializeField] private float _width = 1.0f;

        [SerializeField] private float _speed = 0.5f;

        private Vector3 _startPosition;

        [SerializeField] private bool _static;

        // Start is called before the first frame update
        void Start()
        {
            _startPosition = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_static)
            {
                SlideTarget();
            }
            
        }

        private void SlideTarget()
        {
            float sin = Mathf.Sin(Time.time *  _speed);
            transform.position = _startPosition + new Vector3(_width * sin, 0, 0);
        }
    }
}