using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _rb.useGravity = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _rb.useGravity = false;
    }
}
