using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TableTennis
{
    public class BallProvider : MonoBehaviour
    {
        // 発射するボールプレハブ
        [SerializeField] private GameObject _providedBall;

        //発射ポイントを参照するオブジェクト
        [SerializeField] private GameObject _launchPointObject;

        // ボールを発射するポイント
        private Vector3 _launchPoint;
        
        // ボールを発射する方向
        [SerializeField] private Vector3 _ballDirection;
        
        // 発射するボールの速度
        [SerializeField] private float _speed;

        private float _currentTime;
        [SerializeField] private float _timeSpan;
        void Start()
        {
            _launchPoint = _launchPointObject.GetComponent<Transform>().position;
        }

        // Update is called once per frame
        void Update()
        {           
            // 【Debug】
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BallFiring();
            }

            TimeSpanManagement();
        }

        // 任意の時間感覚でボールを供給する処理
        private void TimeSpanManagement()
        {
            _currentTime += Time.deltaTime;
            
            if (_currentTime > _timeSpan)
            {
                _currentTime = 0;
                BallFiring();
            }
            
        }

        private void BallFiring()
        {
            GameObject ball = Instantiate(_providedBall, _launchPoint, Quaternion.identity);
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            _ballDirection.x = Random.Range(-0.1f, 0.1f);
            _ballDirection.y = _ballDirection.y;
            _ballDirection.z = _ballDirection.z;
            _ballDirection = _ballDirection.normalized;
            ballRB.AddForce(_ballDirection * _speed);
        }
    }
}