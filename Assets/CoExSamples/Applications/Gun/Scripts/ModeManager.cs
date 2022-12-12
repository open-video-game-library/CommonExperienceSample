using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GunGame
{
    public enum PlayMode
    {
        Practice,
        Task
    }

    public class ModeManager : MonoBehaviour
    {
        [SerializeField] private TargetGenerator _targetGenerator;

        [SerializeField] private GameObject _modeSwitchCanvas;

        [SerializeField] private GameObject _resultCanvas;
        
        [SerializeField] private GameObject _timeCanvas;

        [SerializeField] private GameObject _targets;

        [HideInInspector] public PlayMode PlayMode;

        // Start is called before the first frame update
        private void Start()
        {
            SetActiveModeCanvas(true);
            SetActiveResultCanvas(false);
            SetActiveTimeCanvas(false);
        }

        public void SetActiveModeCanvas(bool isOn)
        {
            _modeSwitchCanvas.SetActive(isOn);
        }

        public void SetActiveResultCanvas(bool isOn)
        {
            _resultCanvas.SetActive(isOn);
        }

        public void SetActiveTimeCanvas(bool isOn)
        {
            _timeCanvas.SetActive(isOn);
        }

        public void SwitchTargetPracticeMode()
        {
            PlayMode = PlayMode.Practice;
            _targets.SetActive(true);
            SetActiveResultCanvas(false);
            SetActiveTimeCanvas(false);
        }

        public void SwitchAimingTaskMode()
        {
            PlayMode = PlayMode.Task;
            SetActiveResultCanvas(false);
            SetActiveModeCanvas(false);
            SetActiveTimeCanvas(true);
            _targets.SetActive(false);
            StartCoroutine(_targetGenerator.CountDown());
        }
        
    }
}