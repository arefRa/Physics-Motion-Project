using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace physics.Project
{
    public class PauseAndCalculate : MonoBehaviour
    {
        #region variables & references:

        private static PauseAndCalculate _instance;

        [SerializeField] private Text _pausedText;
        [SerializeField] private GameObject _projectileClone = null;
        [SerializeField] private LayerMask _xAxisLayerMask, _yAxisLayerMask;

        [SerializeField] private Transform _xAxisPrefab, _yAxisPrefab;

        private bool _gameIsPaused = false;

        #region getter & setter:

        public PauseAndCalculate PauseScriptInstance { get => _instance; }

        #endregion

        #endregion

        #region main functions:

        private void Awake()
        {
            if (_instance != null && _instance != this) Destroy(this.gameObject);
            else _instance = this;
        }

        #endregion

        #region private functions:

        private void PauseResumeFunction()
        {
            if (_gameIsPaused)
            {
                Time.timeScale = 1;
                _pausedText.text = "Pause";
                _gameIsPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                _pausedText.text = "Resume";
                CalculateProjectileLocation();
                _gameIsPaused = true;
            }
        }

        private void CalculateProjectileLocation()
        {
            /* _projectileClone = GameObject.Find("CannonBullet(Clone)");
             if (!_projectileClone)
             {
                 RaycastHit2D raycastHit = Physics2D.Raycast(_projectileClone.transform.position, -_projectileClone.transform.right, Mathf.Infinity, _yAxisLayerMask);
                 float xDistance = Vector2.Distance(raycastHit.point, _projectileClone.transform.position);
                 Debug.Log(xDistance);
             }
            */

            _projectileClone = GameObject.Find("CannonBullet(Clone)");
            if (!_projectileClone)
            {
                float xDistance = Vector2.Distance(_xAxisPrefab.position, _projectileClone.transform.position);
                Debug.Log(xDistance);
            }
            else return;
        }

        #endregion

        #region public functions:

        public void ProvokePauseResume() => PauseResumeFunction();

        #endregion
    }
}