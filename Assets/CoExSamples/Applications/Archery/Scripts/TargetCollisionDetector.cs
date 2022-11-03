using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


namespace Archery
{
    public class TargetCollisionDetector : MonoBehaviour
    {
        private CapsuleCollider _collider;

        private TextMeshProUGUI _scoreText;
        
        private SoundManager _soundManager;
        
        
        // name of target tag
        private const string _targetYellowTag = "Target_Yellow";
        private const string _targetRedTag = "Target_Red";
        private const string _targetBlueTag = "Target_Blue";
        private const string _targetBlackTag = "Target_Black";
        private const string _targetWhiteTag = "Target_White";
        private const string _targetTag = "Target";

        // Start is called before the first frame update
        private void Start()
        {
            _collider = gameObject.GetComponent<CapsuleCollider>();
            _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        }
        
        
        private void OnCollisionEnter(Collision collision)
        {
            Freeze(collision);
            
            if (collision.gameObject.CompareTag(_targetYellowTag))
            {
                _scoreText.text = "yellow";
                _scoreText.color = Color.yellow;
                StartCoroutine(ResetScoreText());
                _soundManager.PlayCollisionSound();
                return;
            }
            if (collision.gameObject.CompareTag(_targetRedTag))
            {
                _scoreText.text = "red";
                _scoreText.color = Color.red;
                StartCoroutine(ResetScoreText());
                _soundManager.PlayCollisionSound();
                return;
            }
            if (collision.gameObject.CompareTag(_targetBlueTag))
            {
                _scoreText.text = "blue";
                _scoreText.color = Color.blue;
                StartCoroutine(ResetScoreText());
                _soundManager.PlayCollisionSound();
                return;
            }
            if (collision.gameObject.CompareTag(_targetBlackTag))
            {
                _scoreText.text = "black";
                _scoreText.color = Color.black;
                StartCoroutine(ResetScoreText());
                _soundManager.PlayCollisionSound();
                return;
            }
            if (collision.gameObject.CompareTag(_targetWhiteTag))
            {
                _scoreText.text = "white";
                _scoreText.color = Color.white;
                StartCoroutine(ResetScoreText());
                StartCoroutine(ResetScoreText());
                _soundManager.PlayCollisionSound();
                return;
            }

            if (collision.gameObject.CompareTag(_targetTag))
            {
                _soundManager.PlayCollisionSound();
            }
            
        }
        

        // A method to stop the arrow completely upon collision.
        private void Freeze(Collision collision)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            gameObject.transform.parent = collision.gameObject.transform;
            _collider.enabled = false;
        }

        private IEnumerator ResetScoreText()
        {
            yield return new WaitForSeconds(3);
            _scoreText.text = "";
        }
        
        
    }
}

