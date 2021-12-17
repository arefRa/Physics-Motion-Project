using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace physics.Project
{
    public class ArrowTail : MonoBehaviour
    {
        #region variables & references:

        [SerializeField] private GameObject _dotPrefab;

        [SerializeField] private float _timeInitiation, _timeDurationBetweenDots;

        private TimeController _timer;
        private AdjustThrowingDegree _projectileThrower;

        private Transform _xAxis, _yAxis;

        private Text _xAxisText, _yAxisText;
        private Text _maxHeightTxt;
        private Text _velocityTxt, _velocityInitialTxt;

        private Slider _degreeSlider, _gravitySlider;

        private float _xDistance, _yDistance;
        private float _maxHeight, _degree;

        private float _velocityY, _velocityYInitial;

        private bool _notStopped = true;

        #endregion

        #region main functions:

        private void Start() => Initialize();

        private void Update()
        {
            CalculateDistances();
            if (_notStopped)
                CalculateVelocityY();
        }

        #endregion

        #region private functions:

        private void Initialize()
        {
            _maxHeight = _yDistance;

            _timer = this.gameObject.GetComponent<TimeController>();
            _projectileThrower = GameObject.Find("Cannon").GetComponent<AdjustThrowingDegree>();

            _xAxis = GameObject.Find("X Axis").transform;
            _yAxis = GameObject.Find("Y Axis").transform;

            _degreeSlider = GameObject.Find("Degree Slider").GetComponent<Slider>();
            _gravitySlider = GameObject.Find("Gravity Slider").GetComponent<Slider>();

            _xAxisText = GameObject.Find("X Axis Location").gameObject.transform.GetChild(0).GetComponent<Text>();
            _yAxisText = GameObject.Find("Y Axis Location").gameObject.transform.GetChild(0).GetComponent<Text>();

            _maxHeightTxt = GameObject.Find("Maximum Height").gameObject.transform.GetChild(0).GetComponent<Text>();

            _velocityTxt = GameObject.Find("VelocityY").gameObject.transform.GetChild(0).GetComponent<Text>();
            _velocityInitialTxt = GameObject.Find("VelocityY Initial").gameObject.transform.GetChild(0).GetComponent<Text>();

            _degree = _degreeSlider.value;
            this.GetComponent<Rigidbody2D>().gravityScale = _gravitySlider.value;

            CalculateInitialVelocity();
            CalculateMaxHeight();
        }

        private void CalculateDistances()
        {
            _xDistance = Mathf.Abs((this.transform.position.x - _xAxis.position.y)) * 10;
            if(_notStopped)
            _yDistance = Mathf.Abs((this.transform.position.y - _yAxis.position.x)) * 10;

            _xAxisText.text = _xDistance.ToString("00.00");
            _yAxisText.text = _yDistance.ToString("00.00");
        }

        private void CalculateVelocityY()
        {
            _velocityY = _projectileThrower.LaunchForce - ((this.GetComponent<Rigidbody2D>().gravityScale) * _timer.CurrentTime);
            _velocityTxt.text = _velocityY.ToString("00.00");
        }

        private void CalculateInitialVelocity()
        {
            _velocityYInitial = _projectileThrower.LaunchForce * Mathf.Abs((Mathf.Sin(_degree)));
            _velocityInitialTxt.text = _velocityYInitial.ToString("00.00");
        }

        private void CalculateMaxHeight()
        {
            _maxHeight = Mathf.Pow(_velocityYInitial, 2) / (2 * (this.gameObject.GetComponent<Rigidbody2D>().gravityScale));
            _maxHeightTxt.text = _maxHeight.ToString("00.00"); 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "GroundColliders")
            {
                Rigidbody2D projectileRB = this.gameObject.GetComponent<Rigidbody2D>();
                projectileRB.constraints = RigidbodyConstraints2D.FreezePosition;
                _notStopped = false;

                _yDistance = 0.0f;
                _yAxisText.text = _yDistance.ToString("00.00");

                _timer.StopTimer = true;
                CancelInvoke();
            }               
        }

        private void MakeArrowTrail() => InvokeRepeating("TriggerDots", _timeInitiation, _timeDurationBetweenDots);

        private void TriggerDots() => Instantiate(_dotPrefab, this.transform.position, Quaternion.identity);

        #endregion

        #region public functions:

        public void ProvokeDotTrail() => MakeArrowTrail();

        #endregion
    }
}