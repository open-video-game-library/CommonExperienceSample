using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    public class GenManager : MonoBehaviour
    {
        [SerializeField] private ArrowManager _arrowManager;

        [SerializeField] private GameObject _arrowEndPoint;
       

        // Update is called once per frame
        void Update()
        {
            if (_arrowManager.Drawable)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _arrowEndPoint.transform.position.z);
            }
        }
    }
}