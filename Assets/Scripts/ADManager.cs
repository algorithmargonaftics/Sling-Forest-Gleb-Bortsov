using UnityEngine;
using System;
using Interfaces.Panels;

namespace ADS
{
    public class ADManager : MonoBehaviour
    {
        #region ACTION

        public static Action OnContinuationGame = null;

        #endregion


        #region MONO

        private void OnEnable()
        {
            LoseLevelPanel.OnWatchAdToRestart += WatchADS;
        }

        private void OnDisable()
        { 
            LoseLevelPanel.OnWatchAdToRestart -= WatchADS;
        }

        #endregion

        #region Private Methods

        private void WatchADS()
        {
            OnContinuationGame?.Invoke();
        }

        #endregion
    }
}