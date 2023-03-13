using UnityEngine;
using Location;

namespace Configs
{
    [CreateAssetMenu(fileName = "Level", menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        [Header("Location Parameters")]
        [SerializeField] private Chunk[] _chunkPrefab;
        [Space (height: 5f)]

        [SerializeField] private Chunk _finishChunkPrefab;

        [Header("Location Parameters")]
        [SerializeField] private int _maxSlingCount = 10;
        [SerializeField] private int _continuationSlingCount = 3;

        #region Public Fields

        public Chunk[] ChunkPrefab => _chunkPrefab;
        public Chunk FinishChunkPrefab => _finishChunkPrefab;

        public int MaxSlingCount => _maxSlingCount;
        public int ContinuationSlingCount => _continuationSlingCount;

        #endregion
    }
}