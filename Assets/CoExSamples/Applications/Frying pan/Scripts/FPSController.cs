using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fryingpan
{
    public class FPSController : MonoBehaviour
    {
        [SerializeField] private int _framePerSecond;
        // Start is called before the first frame update
        void Start()
        {
            Application.targetFrameRate = _framePerSecond;
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

