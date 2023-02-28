using UnityEngine;
using Players;
using DG.Tweening;

namespace Character.Slingshot
{
    [RequireComponent(typeof(Player_Movement))]
    public class Player_Slingshot : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private float _maxSlingDistance = 2f;

        [SerializeField] private float _movingTime = 1f;

        [Header("Private")]
        private Vector3 _directionMove = Vector3.zero;

        private Joystick _slingJoystick = null;


        #region MONO

        private void Awake()
        {
            _slingJoystick = FindObjectOfType<Joystick>();
        }

        private void Update()
        {
            OnSlinging();
        }

        private void OnEnable()
        {
            //DynamicJoystick.OnStartingGame += OnSlinging; //Оттягивание
            DynamicJoystick.OnStartGame += OnMoving;
        }

        private void OnDisable()
        {
            //DynamicJoystick.OnStartingGame -= OnSlinging;
            DynamicJoystick.OnStartGame -= OnMoving;
        }

        #endregion

        #region Private Methods

        private void OnSlinging()
        {
            float horizontal = _slingJoystick.Horizontal;
            float vertical = _slingJoystick.Vertical;

            _directionMove = new Vector3(-horizontal, gameObject.transform.position.y, -vertical);
        }

        private void OnMoving()
        {
            float newXPosition = gameObject.transform.position.x + (_maxSlingDistance * _directionMove.x);
            float newZPosition = gameObject.transform.position.z + (_maxSlingDistance * _directionMove.z);

            Vector3 newPosition = new Vector3(newXPosition, gameObject.transform.position.y, newZPosition);

            gameObject.transform.DOMove(newPosition, _movingTime);
        }

        #endregion
    }
}