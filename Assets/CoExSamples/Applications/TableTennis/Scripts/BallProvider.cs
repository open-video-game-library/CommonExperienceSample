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
        // Start is called before the first frame update
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
        }

        private void BallFiring()
        {
            GameObject ball = Instantiate(_providedBall, _launchPoint, Quaternion.identity);
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            _ballDirection.x = Random.Range(-0.25f, 0.25f);
            _ballDirection.y = _ballDirection.y;
            _ballDirection.z = _ballDirection.z;
            _ballDirection = _ballDirection.normalized;
            ballRB.AddForce(_ballDirection * _speed);
        }
    }
}