using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace physics.Project
{
    public class TimeController : MonoBehaviour
    {
        #region variables & references:

        [SerializeField] private Text _timerTxt;

        private float _currentTime;

        private bool _stopTimer = false;

        #region getter & setter:

        public float CurrentTime { get => _currentTime; set => _currentTime = value; }

        public bool StopTimer { get => _stopTimer; set => _stopTimer = value; }

        #endregion

        #endregion

        #region main functions:

        private void Start() => Initialize();

        private void Update()
        {
            if (!StopTimer)
                UpdateTime();
        }

        #endregion

        #region private functions:

        private void Initialize()
        {
            _currentTime = 0;
            _timerTxt = GameObject.Find("Timer").gameObject.transform.GetChild(1).GetComponent<Text>();
        }

        private void UpdateTime()
        {
            _currentTime += Time.deltaTime;
            _timerTxt.text = _currentTime.ToString("00.00.00");
        }

        #endregion
    }
}