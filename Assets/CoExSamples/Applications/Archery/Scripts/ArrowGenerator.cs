using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archery
{
    public class ArrowGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _arrow;

        // Start is called before the first frame update
        private void Start()
        {
            // Initial arrow generation
            InstantiateArrow();
        }

        // Update is called once per frame
        private void Update()
        {
#if UNITY_EDITOR
            if(Input.GetMouseButton(0))
            {
                InstantiateArrow();
            }
#elif UNITY_ANDROID
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                InstantiateArrow();
            }
#endif
        }

        private void InstantiateArrow()
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.17f);
            Instantiate(_arrow, pos, Quaternion.identity);
        }
    }
}