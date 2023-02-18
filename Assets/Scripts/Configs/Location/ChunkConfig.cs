using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Chunk", menuName = "Configs/Chunk")]
    public class ChunkConfig : ScriptableObject
    {
        [Header("Chunk Parameters")]
        [SerializeField] private float _xSpawnerPosition = 6.5f;


        #region Private Fields

        public float XSpawnerPosition => _xSpawnerPosition;

        #endregion
    }
}