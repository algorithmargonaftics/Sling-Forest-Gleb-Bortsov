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

        private const int NUMBER_WALL = 2;

        #endregion

        [SerializeField] private ChunkConfig _parameters;

        [Header("Parameters")]
        public Transform Start;
        public Transform End;
        [Space(height: 5f)]

        private float _xPosition = 0f;

        #region Private Methods

        private float _xSpawnerPosition => _parameters.XSpawnerPosition;

        #endregion


        #region Public Methods

        #endregion
    }
}