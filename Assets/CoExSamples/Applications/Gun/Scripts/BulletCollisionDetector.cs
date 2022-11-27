using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GunGame
{
    public class BulletCollisionDetector : MonoBehaviour
    {
        private const string _targetYellowTag = "Target_Yellow";
        private const string _targetRedTag = "Target_Red";
        private const string _targetBlueTag = "Target_Blue";
        private const string _targetBlackTag = "Target_Black";
        private const string _targetWhiteTag = "Target_White";
        private const string _taskTarget = "TaskTarget";
        private const string _targetPracticeTag = "Target_Practice";
        private const string _targetTaskTag = "Target_Task";

        private TextMeshProUGUI _scoreText;
        private const string _scoreTextName = "ScoreCanvas/ScoreText";
        
        private AudioSource _hitTargetSound;

        private TargetGenerator _targetGenerator;

        private ModeManager _modeManager;

        [SerializeField] private AudioClip _crackAudioClip;
        [SerializeField] private AudioClip _collisionAudioClip;
        
        // Start is called before the first frame update
        private void Start()
        {
            _targetGenerator = GameObject.Find("TargetGenerator").GetComponent<TargetGenerator>();
            _hitTargetSound = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            _modeManager = GameObject.Find("ModeManager").GetComponent<ModeManager>();
        }

        
        private void OnCollisionEnter(Collision collision)
        {
            if (_modeManager.PlayMode == PlayMode.Practice)
            {
                DetectPracticeTarget(collision.gameObject);
                DetectPlayMode(collision.gameObject);
                return;
            }
            if (_modeManager.PlayMode == PlayMode.Task)
            {
                DetectSphereTarget(collision.gameObject);
            }
        }

        private void DetectPlayMode(GameObject collisionGameObject)
        {
            if (collisionGameObject.CompareTag(_targetPracticeTag))
            {
                _modeManager.SwitchTargetPracticeMode();
                _hitTargetSound.PlayOneShot(_collisionAudioClip);
            }
            else if (collisionGameObject.CompareTag(_targetTaskTag))
            {
                _modeManager.SwitchAimingTaskMode();
                _hitTargetSound.PlayOneShot(_collisionAudioClip);
            }
            
            StartCoroutine(DestroyBullet());
        }

        private void DetectSphereTarget(GameObject collisionGameObject)
        {
            if (collisionGameObject.CompareTag(_taskTarget))
            {
                _targetGenerator.DestroyTarget();
                _hitTargetSound.PlayOneShot(_crackAudioClip);
                _targetGenerator.GenerateFragment(collisionGameObject.transform.position);
            }

            StartCoroutine(DestroyBullet());
        }

        private void DetectPracticeTarget(GameObject collisionGameObject)
        {
            if (collisionGameObject.transform.parent.Find(_scoreTextName) == null)
            {
                return;
            }
            
            _scoreText = collisionGameObject.transform.parent.Find(_scoreTextName).GetComponent<TextMeshProUGUI>();

            if (collisionGameObject.CompareTag(_targetYellowTag))
            {
                Hit(Color.yellow, _scoreText);
                return;
            }
            if (collisionGameObject.CompareTag(_targetRedTag))
            {
                Hit(Color.red, _scoreText);
                return;
            }
            if (collisionGameObject.CompareTag(_targetBlueTag))
            {
                Hit(Color.blue, _scoreText);
                return;
            }
            if (collisionGameObject.CompareTag(_targetBlackTag))
            {
                Hit(Color.black, _scoreText);
                return;
            }
            if (collisionGameObject.CompareTag(_targetWhiteTag))
            {
                Hit(Color.white, _scoreText);
            }
            
            StartCoroutine(DestroyBullet());
        }
        
        private void Hit(Color textColor, TextMeshProUGUI scoreText)
        {
            _hitTargetSound.PlayOneShot(_collisionAudioClip);
            _scoreText.color = textColor;
            _scoreText.text = "Hit";
            StartCoroutine(DeleteScoreText());
        }
        
        private IEnumerator DeleteScoreText()
        {
            yield return new WaitForSeconds(1);
            _scoreText.text = "";
        }

        private IEnumerator DestroyBullet()
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }

}
