using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Chunk", menuName = "Configs/Chunk")]
    public class ChunkConfig : ScriptableObject
    {
        [Header("Chunk Parameters")]
        [SerializeField] private float _xSpawnerPosition = 6.5f;
        [Space(height: 5f)]

        [Header("Obstructions")]
        [SerializeField] private GameObject _obstructionObject = null;


        #region Private Fields

        public float XSpawnerPosition => _xSpawnerPosition;

        public GameObject ObstructionObject => _obstructionObject;

        #endregion
    }
}