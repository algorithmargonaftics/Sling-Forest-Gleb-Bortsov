using UnityEngine;
using UnityEngine.UI;
using Scenes;

namespace Interfaces.Panels
{
    public class FinishLevelPanel : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _nextLevelButton = null;

        private SceneTrancition _sceneTrancition = null;


        #region MONO

        private void Awake() => _sceneTrancition = new SceneTrancition();

        private void Start()
        {
            _nextLevelButton.onClick.AddListener(() => _sceneTrancition.OnTrancitionToNextScene());
        }

        #endregion
    }
}