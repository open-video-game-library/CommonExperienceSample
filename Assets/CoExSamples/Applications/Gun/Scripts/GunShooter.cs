using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GunGame
{
    public class GunShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _muzzle;

        private const string _targetYellowTag = "Target_Yellow";
        private const string _targetRedTag = "Target_Red";
        private const string _targetBlueTag = "Target_Blue";
        private const string _targetBlackTag = "Target_Black";
        private const string _targetWhiteTag = "Target_White";

        private TextMeshProUGUI _scoreText;
        private const string _scoreTextName = "ScoreCanvas/ScoreText";

        [SerializeField] private AudioSource _shootSound;

        [SerializeField] private AudioSource _hitTargetSound;

        private Animation _shootAnimation;
        // Start is called before the first frame update
        void Start()
        {
            _shootAnimation = this.GetComponent<Animation>();
        }

        // Update is called once per frame
        void Update()
        {
            #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.A))  
            {
                Fire();
            }
            #elif UNITY_ANDROID
            if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))  
            {
                Fire();
            }
            #endif
        }

        private void Fire()
        {
            _shootSound.Play();
            _shootAnimation.Play();
            RaycastHit hit;
            if (Physics.Raycast(_muzzle.transform.position, _muzzle.transform.forward, out hit, 1000))
            {
                // Debug
                Debug.DrawRay(_muzzle.transform.position, _muzzle.transform.forward * 1000, Color.blue);

                if (hit.collider.transform.parent.Find(_scoreTextName) == null)
                {
                    return;
                }
                else
                {
                    _scoreText = hit.collider.transform.parent.Find(_scoreTextName)
                        .GetComponent<TextMeshProUGUI>();
                }
                
                if (hit.collider.CompareTag(_targetYellowTag))
                {
                    Debug.Log(hit.collider.transform.parent.gameObject.name);
                    Hit(1000,Color.yellow);
                    return;
                }
                else if (hit.collider.CompareTag(_targetRedTag))
                {
                    Hit(800,Color.red);
                    return;
                }
                else if (hit.collider.CompareTag(_targetBlueTag))
                {
                    Hit(600,Color.blue);
                    return;
                }
                else if (hit.collider.CompareTag(_targetBlackTag))
                {
                    Hit(400,Color.black);
                    return;
                }
                else if (hit.collider.CompareTag(_targetWhiteTag))
                {
                    Hit(200,Color.white);
                }
            }
        }

        private void Hit(int score,Color textColor)
        {
            _hitTargetSound.Play();
            _scoreText.color = textColor;
            _scoreText.text = score.ToString();
            StartCoroutine(DeleteScoreText());
        }

        IEnumerator DeleteScoreText()
        {
            yield return new WaitForSeconds(3.5f);
            _scoreText.text = "";
        }
    }
}