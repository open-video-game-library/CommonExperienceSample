using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunGame
{
    public class TargetSlider : MonoBehaviour
    {
        [SerializeField] private float _width;

        [SerializeField] private float _speed;

        private Vector3 _startPosition;

        // Start is called before the first frame update
        void Start()
        {
            _startPosition = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            SlideTarget();
        }

        private void SlideTarget()
        {
            float sin = Mathf.Sin(Time.time *  _speed);
            transform.position = _startPosition + new Vector3(_width * sin, 0, 0);
        }
    }
}