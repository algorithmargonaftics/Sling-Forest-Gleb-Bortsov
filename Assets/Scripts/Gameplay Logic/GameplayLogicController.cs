using UnityEngine;
using Character;
using Character.Slingshot;
using Interfaces.Panels;

namespace Gameplay
{
    public class GameplayLogicController : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private FinishLevelPanel _finishLevelPanel = null;
        [SerializeField] private LoseLevelPanel _loseLevelPanel = null;


        #region MONO

        private void Start()
        {
            _finishLevelPanel.gameObject.SetActive(false);
            _loseLevelPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            Player_Movement.OnFinishLevel += OnFinishLevel;
            Player_Slingshot.OnZeroCount += OnLoseLevel;
        }

        private void OnDisable()
        {
            Player_Movement.OnFinishLevel -= OnFinishLevel;
            Player_Slingshot.OnZeroCount -= OnLoseLevel;
        }

        #endregion

        #region Private Methods

        private void OnFinishLevel()
        {
            _finishLevelPanel.gameObject.SetActive(true);
        }

        private void OnLoseLevel()
        {
            _loseLevelPanel.gameObject.SetActive(true);

        }

        #endregion
    }
}