using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace physics.Project
{
    public class ResetStates : MonoBehaviour
    {
        #region private function:

        private void ResetGameScene() => SceneManager.LoadScene("SampleScene");

        #endregion

        #region public functions:

        public void ProvokeSceneReset() => ResetGameScene();

        #endregion
    }
}