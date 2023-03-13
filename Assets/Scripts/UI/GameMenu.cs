using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using TechSettings;

namespace Interfaces
{
    public class GameMenu : MonoBehaviour
    {
        #region CONSTS

        private const float TIME_ANIMATION = 2f;

        private const int Y_POSITION = -2340;

        #endregion

        [SerializeField] private RectTransform _canvasRectTransform;


        #region MONO

        private void OnEnable() => DynamicJoystick.OnStartingGame += OnStartGame;

        private void OnDisable() => DynamicJoystick.OnStartingGame -= OnStartGame;

        #endregion

        #region Private Methods

        private void OnStartGame() => StartCoroutine(StartGameCoroutine());

        private IEnumerator StartGameCoroutine()
        {
            _canvasRectTransform.DOAnchorPosY(Y_POSITION, TIME_ANIMATION);

            yield return new WaitForSeconds(TIME_ANIMATION);

            gameObject.SetActive(false);

            yield break;
        }

        #endregion
    }
}