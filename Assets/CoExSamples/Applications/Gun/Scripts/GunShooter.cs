using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GunGame
{
    public class GunShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _muzzle;
        
        private TextMeshProUGUI _scoreText;
        
        [SerializeField] private AudioSource _shootSound;

        private Animation _shootAnimation;

        private bool _isDefaultVibration;
        
        [SerializeField] private GameObject _bulletPrefab;
        
        [HideInInspector] public OVRInput.Controller GrabHand;

        [SerializeField] private ModeManager _modeManager;

        [SerializeField] private TargetGenerator _targetGenerator;
        
        // Start is called before the first frame update
        private void Start()
        {
            _isDefaultVibration = true;
            _shootAnimation = GetComponent<Animation>();
        }

        // Update is called once per frame
        private void Update()
        {
#if UNITY_ANDROID
            if (GrabHand == OVRInput.Controller.RTouch)
            {
                if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Fire(GrabHand);
                }
            }

            if (GrabHand == OVRInput.Controller.LTouch)
            {
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    Fire(GrabHand);
                }
            }
            
#endif
        }

        private void Fire(OVRInput.Controller controller)
        {
            if(_isDefaultVibration) StartCoroutine(Vibrate(0.1f, 0.1f, 1f, controller));
            _shootSound.Play();
            _shootAnimation.Play();
            
            // Firing bullet
            ShootBullet();

            if (_modeManager.PlayMode == PlayMode.Task)
            {
                _targetGenerator.ShotNumber ++;
            }
        }

        private void ShootBullet()
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _muzzle.transform.position;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(4000 * _muzzle.transform.forward);
        }

        private IEnumerator Vibrate(float duration, float frequency, float amplitude, OVRInput.Controller controller) {
            //コントローラーを振動させる
            OVRInput.SetControllerVibration(frequency, amplitude, controller);

            //指定された時間待つ
            yield return new WaitForSeconds(duration);

            //コントローラーの振動を止める
            OVRInput.SetControllerVibration(0, 0, controller);
        }
        
    }
}