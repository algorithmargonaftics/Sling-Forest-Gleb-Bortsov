using UnityEngine;
using UnityEngine.UI;
using Character;

namespace Gameplay
{
    public class GameplayLogicController : MonoBehaviour
    {
        //[Header("Panels")]
        //[SerializeField] private FinishLevelPanel _finishLevelPanel = null;


        #region MONO

        private void OnEnable()
        {
            Player_Movement.OnFinishLevel += OnFinishLevel;
        }

        private void OnDisable()
        {
            Player_Movement.OnFinishLevel -= OnFinishLevel;
        }

        #endregion

        #region Private Methods

        private void OnFinishLevel()
        {
            //_finishLevelPanel.gameObject.SetActive(true);
            Debug.Log("Finish");
        }

        #endregion

        ///start ui
        ///trigger = final
        ///action = end
    }
}