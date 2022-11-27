using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace GunGame
{
    public class TargetGenerator : MonoBehaviour
    {
        // Width and height of target appearance
        [SerializeField] private float _width;
        [SerializeField] private float _height;
        
        
        // Gun task time limit (seconds)
        [SerializeField] private int _timeLimit;

        // Target game object
        [SerializeField] private GameObject _targetPrefab;

        // Distance to target
        [SerializeField] private float _targetDistance;
        
        [HideInInspector] public bool Playing;
        
        private float _taskElapsedTime;

        private GameObject _target;

        private  float _score;

        public float ShotNumber;

        [SerializeField] private TextMeshProUGUI _hitCountText;
        
        [SerializeField] private TextMeshProUGUI _hitRateText;

        [SerializeField] private TextMeshProUGUI _timeText;

        private float _standardHeight;

        [SerializeField] private ModeManager _modeManager;

        [SerializeField] private GameObject _fragment;

        // Start is called before the first frame update
        private void Start()
        {
            _standardHeight = 1.5f;
            //VisualizeTargetGenerateScope();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Playing)
            {
                return;
            }

            _taskElapsedTime += Time.deltaTime;
            if (_taskElapsedTime <= _timeLimit)
            {
                _timeText.text = ((int)(_timeLimit - _taskElapsedTime)).ToString();
                if (_target == null)
                {
                    GenerateTarget();
                }
            }
            else
            {
                FinishTask();
            }
            
            
            
        }

        private void GenerateTarget()
        {
            _target = Instantiate(_targetPrefab);
            float posX = Random.Range(-_width / 2, _width / 2);
            float posY = Random.Range(-_height / 2 + _standardHeight, _height / 2 + _standardHeight);
            _target.transform.position = new Vector3(posX, posY, _targetDistance);
        }

        public void DestroyTarget()
        {
            _hitCountText.text = "called";
            Destroy(_target);
            _score ++;
        }

        public IEnumerator CountDown()
        {
            // Initialize
            _score = 0;
            ShotNumber = 0;
            _hitCountText.text = "";
            _hitRateText.text = "";
            _timeText.text = "";
            
            yield return new WaitForSeconds(1.0f);
            
            // countdown start.
            _timeText.text = "3";
            yield return new WaitForSeconds(1.0f);
            _timeText.text = "2";
            yield return new WaitForSeconds(1.0f);
            _timeText.text = "1";
            yield return new WaitForSeconds(1.0f);
            Playing = true;
            _timeText.text = "Start";
            yield return new WaitForSeconds(2.0f);
            _timeText.text = "";
        }

        public void GenerateFragment(Vector3 position)
        {
            Instantiate(_fragment, position, Quaternion.identity);
        }

        private void FinishTask()
        {
            _hitCountText.text = _score.ToString();
            _hitRateText.text = Mathf.Round(100 * _score / ShotNumber) + "% (" + _score + "/" + ShotNumber + ")";
            _modeManager.SetActiveResultCanvas(true);
            _modeManager.PlayMode = PlayMode.Practice;
            Playing = false;
            _modeManager.SetActiveModeCanvas(true);
            _modeManager.SetActiveTimeCanvas(false);
            _taskElapsedTime = 0;
                
            if (_target != null)
            {
                Destroy(_target);
            }
        }
        
        /// <summary>
        /// Visualization of target appearance range
        /// </summary>
        private void VisualizeTargetGenerateScope()
        {
            Vector3[] positions = new Vector3[]
            {
                new Vector3(_width / 2, _height / 2 + _standardHeight, _targetDistance),
                new Vector3(_width / 2, -_height / 2 + _standardHeight, _targetDistance),
                new Vector3(-_width / 2, -_height / 2 + _standardHeight, _targetDistance),
                new Vector3(-_width / 2, _height / 2 + _standardHeight, _targetDistance),
                new Vector3(_width / 2, _height / 2 + _standardHeight, _targetDistance),
            };
            LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
            lineRenderer.positionCount = 5;
            lineRenderer.SetPositions(positions);
        }
    }
}