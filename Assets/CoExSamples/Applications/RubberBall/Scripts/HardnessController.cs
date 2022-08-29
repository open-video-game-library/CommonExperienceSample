using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardnessController : MonoBehaviour
{
    [SerializeField, Range(0, 1.0f)]
    private float _hardness;

    private Transform _ballTransform;

    private float _initialScale;
    // Start is called before the first frame update
    void Start()
    {
        _ballTransform = gameObject.GetComponent<Transform>();
        _initialScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        _ballTransform.localScale = new Vector3(_hardness * _initialScale,  _initialScale,_initialScale);
    }
}
