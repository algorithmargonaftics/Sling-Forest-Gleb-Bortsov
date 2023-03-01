using UnityEngine;
using System.Collections;
using Players;
using DG.Tweening;

namespace Character.Slingshot
{
    [RequireComponent(typeof(Player_Movement))]
    public class Player_Slingshot : MonoBehaviour
    {
        #region CONSTS

        private const float MINUS_TIME = 0.2f;

        #endregion

        [Header("Parameters")]
        [SerializeField] private float _maxMoveDistance = 2f;
        [SerializeField] private float _movingTime = 1f;

        [Header("Private")]
        [SerializeField] private bool _isMoving = false;

        private Vector3 _directionMove = Vector3.zero;

        private Joystick _slingJoystick = null;


        #region MONO

        private void Awake() => _slingJoystick = FindObjectOfType<Joystick>();

        private void Update() => OnSlinging();

        private void OnEnable() => DynamicJoystick.OnStartGame += OnMoving;

        private void OnDisable() => DynamicJoystick.OnStartGame -= OnMoving;

        #endregion

        #region Private Methods

        private void OnSlinging()
        {
            if (_isMoving == true) return;

            float horizontal = _slingJoystick.Horizontal;
            float vertical = _slingJoystick.Vertical;

            _directionMove = new Vector3(-horizontal, gameObject.transform.position.y, -vertical);

            RotationModel();
        }

        private void OnMoving()
        {
            if (_isMoving == true) return;

            _isMoving = true;

            float newXPosition = gameObject.transform.position.x + (_maxMoveDistance * _directionMove.x);
            float newZPosition = gameObject.transform.position.z + (_maxMoveDistance * _directionMove.z);

            Vector3 newPosition = new Vector3(newXPosition, gameObject.transform.position.y, newZPosition);

            gameObject.transform.DOMove(newPosition, _movingTime);

            StartCoroutine(IsMovingCoroutine());
        }

        private void RotationModel()
        {
            if (_slingJoystick.Horizontal == 0 || _slingJoystick.Vertical == 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                return;
            }

            float angle = Mathf.Atan2(_directionMove.x, _directionMove.z) * Mathf.Rad2Deg;

            gameObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        #region Coroutine

        private IEnumerator IsMovingCoroutine()
        {
            yield return new WaitForSeconds(_movingTime - MINUS_TIME);

            _isMoving = false;

            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            yield break;
        } 

        #endregion

        #endregion
    }
}