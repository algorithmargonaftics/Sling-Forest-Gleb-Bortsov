using UnityEngine;
using Configs;

namespace Location
{
    public enum TypePosition
    {
        Left,
        Center,
        Right,
        Non
    }

    public class Chunk : MonoBehaviour
    {
        #region CONST

        private const float Y_POSITION = 1f;

        #endregion

        [SerializeField] private ChunkConfig _parameters;

        [Header("Parameters")]
        public Transform Start;
        public Transform End;
        [Space (height: 5f)]

        [SerializeField] private TypePosition _typePosition;

        private float _xPosition = 0f;

        #region Private Methods

        private float _xSpawnerPosition => _parameters.XSpawnerPosition;

        private GameObject _blockObstructions => _parameters.ObstructionObject;

        #endregion


        #region Public Methods

        public void Create()
        {
            if (_typePosition == TypePosition.Non) return;
 
            GameObject obstruction = Instantiate(_blockObstructions);

            if (_typePosition == TypePosition.Left)
            {
                _xPosition = -_xSpawnerPosition;
            }
            else if (_typePosition == TypePosition.Center)
            {
                _xPosition = 0f;
            }
            else if (_typePosition == TypePosition.Right)
            {
                _xPosition = _xSpawnerPosition;
            }

            obstruction.gameObject.transform.position = new Vector3(_xPosition, Y_POSITION, gameObject.transform.position.z);
        }

        #endregion
    }
}