using UnityEngine;
using Players;

namespace Players.Camera
{
    public class Camera_Follow : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private float _distanceFollow = 5f;

        [SerializeField] private Vector3 _offset = Vector3.zero;

        private Player_Movement _player = null;


        #region MONO

        private void Awake()
        {
            _player = FindObjectOfType<Player_Movement>();
        }

        #endregion

        private void Update()
        {
            CharacterFollowing();
        }

        #region Private Methods

        private void CharacterFollowing()
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, _player.transform.position.z - _distanceFollow - _offset.z);
        }

        #endregion
    }
}