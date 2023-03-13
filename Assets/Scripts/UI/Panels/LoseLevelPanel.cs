using UnityEngine;
using UnityEngine.UI;
using System;
using Scenes;

namespace Interfaces.Panels
{
    public class LoseLevelPanel : MonoBehaviour
    {
        #region ACTION

        public static Action OnWatchAdToRestart = null;

        #endregion

        [Header("Buttons")]
        [SerializeField] private Button _restartCurrentLevelButton = null;
        [SerializeField] private Button _watchAdButton = null;

        private SceneTrancition _sceneTrancition = null;


        #region MONO

        private void Awake() => _sceneTrancition = new SceneTrancition();

        private void Start()
        {
            _restartCurrentLevelButton.onClick.AddListener(() => _sceneTrancition.OnTrancitionToCurrentScene());
            _watchAdButton.onClick.AddListener(() => OnWatchAdToRestart?.Invoke());
        }

        #endregion

        #region Private Methods

        

        #endregion
    }
}