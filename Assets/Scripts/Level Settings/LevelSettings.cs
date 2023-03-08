using UnityEngine;
using Configs;
using System;

namespace Levels.Settings
{
    public class LevelSettings : MonoBehaviour
    {
        #region ACTION

        public static Action<int> OnSetMaxSlingCount = null;

        #endregion

        [Header("Config")]
        [SerializeField] private LevelConfig _levelConfig = null;

        #region Private Fields

        private int _maxSlingCount => _levelConfig.MaxSlingCount;

        #endregion


        #region MONO

        private void Start()
        {
            OnSetMaxSlingCount?.Invoke(_maxSlingCount);
        }

        #endregion
    }
}