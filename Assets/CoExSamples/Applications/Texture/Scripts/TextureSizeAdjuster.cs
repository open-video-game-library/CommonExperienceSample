using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSizeAdjuster : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _textureRatio;

    private Vector3 _defaultScale { get { return new Vector3(0.05f, 0.05f, 0.05f);}}

    // Start is called before the first frame update
    void Start()
    {
        _textureRatio = 10.24f / _spriteRenderer.sprite.bounds.size.x;
        gameObject.transform.localScale = _defaultScale *_textureRatio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
