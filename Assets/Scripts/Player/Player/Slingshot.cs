using UnityEngine;
using System.Collections;
using Players;

namespace Character.Slingshot
{
    public class Slingshot : MonoBehaviour
    {
        #region CONSTS

        private const float DIVISION_SLINGSHOT_FORCE = 5f;
        private const float Z_POSITION = 4f;

        #endregion

        [Header("Parameters")]
        [SerializeField] private Transform _startBorder = null;
        private Transform _player = null;
        [Space(height: 5f)]

        [SerializeField] private float _maxDistanceTencion = 4f;
        [Space(height: 5f)]

        [SerializeField] private Joystick _joysticForceTencion = null;

        private bool _isStartingGame = false;

        private Vector3 _startPosition;
        private Vector3 _newPosition;


        #region MONO

        private void Awake()
        {
            _player = FindObjectOfType<Player_Movement>().GetComponent<Transform>();
        }


        private void Start()
        {
            _startPosition = _startBorder.position;
        }


        private void OnEnable()
        {
            //DynamicJoystick.OnStartGame.AddListener(OnStartGame);
        }

        #endregion

        private void Update()
        {
            TencioningSlingshot();
        }

        #region Private Methods

        private void TencioningSlingshot()
        {
            _newPosition = new Vector3(_startBorder.position.x, _startBorder.position.y, _startBorder.position.z + _joysticForceTencion.Vertical / DIVISION_SLINGSHOT_FORCE);

            if (_newPosition.z < _startPosition.z - _maxDistanceTencion)
            {
                return;
            }
            else if (_newPosition.z > _startPosition.z)
            {
                return;
            }

            _startBorder.position = _newPosition;

            if (_isStartingGame == true)
            {
                StartCoroutine(StartingCoroutine());
            }

            _newPosition = new Vector3(_player.position.x, _player.position.y, _newPosition.z + _player.position.y + Z_POSITION);

            _player.position = _newPosition;
        }

        /*
        private void OnStartGame(float force)
        {
            _isStartingGame = true;
        }
        */

        #endregion

        private IEnumerator StartingCoroutine()
        {
            float time = 0.1f;

            yield return new WaitForSeconds(time);

            _startBorder.position = _newPosition;

            yield break;
        }
    }
}