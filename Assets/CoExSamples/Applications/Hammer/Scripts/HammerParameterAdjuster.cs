using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerParameterAdjuster : MonoBehaviour
{
    [SerializeField] private GameObject _hammerHead;
    [SerializeField] private GameObject _hammerShaft;
    private Vector3 _hammerHeadInitialScale;
    private Vector3 _hammerShaftInitialScale;
    [SerializeField] private float _hammerHeadScale;
    [SerializeField] private float _hammerShaftScale;

    [SerializeField] private Slider _hammerShaftScaleSlider;
    [SerializeField] private Slider _hammerHeadScaleSlider;

    [SerializeField] private bool _adjustableMode;
    private void Start()
    {
        _hammerHeadInitialScale = _hammerHead.transform.localScale;
        _hammerShaftInitialScale = _hammerShaft.transform.localScale;
    }

    private void SetHammerParameter()
    {
        _hammerHead.transform.localScale = _hammerHeadInitialScale * _hammerHeadScale;
        _hammerShaft.transform.localScale = _hammerShaftInitialScale * _hammerShaftScale;
    }

    private void Update()
    {
        if (_adjustableMode)
        {
            _hammerHeadScale = _hammerHeadScaleSlider.value;
            _hammerShaftScale = _hammerShaftScaleSlider.value;
            SetHammerParameter();
        }
        
    }
    
    
}
