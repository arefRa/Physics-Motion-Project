using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace physics.Project
{
    public class GameManager : MonoBehaviour
    {
        #region variables & references:

        [SerializeField] private GameObject _pauseMenuPanel;

        private static bool _pauseMenuActive = false;

        #region getter & setter:

        public bool PauseMenuActive { get => _pauseMenuActive; set => _pauseMenuActive = value; }

        #endregion

        #endregion

        #region main functions:

        private void Start() => Initialize();

        #endregion

        #region private functions:

        private void Initialize()
        {
            _pauseMenuPanel = GameObject.Find("General Pause Panel");
            _pauseMenuPanel.SetActive(false);
        }

        private void PauseMenuHandling()
        {
            if (!PauseMenuActive)
            {
                _pauseMenuPanel.SetActive(true);
                PauseMenuActive = true;
            }
            else
            {
                _pauseMenuPanel.SetActive(false);
                PauseMenuActive = false;
            }
        }

        private void ExitGameFunctionality() => Application.Quit();

        #endregion

        #region public functions:

        public void ProvokePauseMenu() => PauseMenuHandling();

        public void ProvokeExitGame() => ExitGameFunctionality();

        #endregion
    }
}