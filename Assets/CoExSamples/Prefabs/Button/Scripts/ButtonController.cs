using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool _buttonPushed;
    private Vector3 _initialButtonPosition;
    [SerializeField] private float _deepestButtonPositionY;
    [SerializeField] private AudioSource _buttonAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        _initialButtonPosition = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_buttonPushed)
        {
            if (transform.localPosition.y <= _deepestButtonPositionY)
            {
                _buttonPushed = true;
                _buttonAudioSource.Play();
            }
        }
        
    }

    
    private void OnCollisionExit(Collision other)
    {
        
        StartCoroutine(PlayButtonAnimation());
    }

    private IEnumerator PlayButtonAnimation()
    {
        while (true)
        {
            if (transform.localPosition.y < _initialButtonPosition.y)
            {
                transform.Translate(0, 0.01f, 0);
            }
            else
            {
                transform.localPosition = _initialButtonPosition;
                _buttonPushed = false;
            }
            
            yield return null;
        }
    }
}
