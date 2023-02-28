using UnityEngine;
using Players;

namespace Character.Slingshot
{
    [RequireComponent(typeof(Player_Movement))]
    public class Player_Slingshot : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private float _maxSlingDistance = 3f;

        [Header("Private")]
        [SerializeField] private Vector3 _directionMove = Vector3.zero;

        [SerializeField] private Joystick _slingJoystick = null; //_maxSlingValue

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

            //Debug.Log($"h - {horizontal} v - {vertical} d - {_directionMove}");
        }

        private void OnMoving()
        {
            Debug.Log($"OnMoving() dir = {_directionMove}");
        }

        #endregion
    }
}