using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPositionCOntroller : MonoBehaviour
{
    [SerializeField] private Transform _rightControllerTransform;
    [SerializeField] private Transform _leftControllerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = _rightControllerTransform.position;
        gameObject.transform.rotation = _rightControllerTransform.rotation;
    }
}
