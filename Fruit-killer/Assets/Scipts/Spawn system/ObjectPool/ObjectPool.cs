using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    private struct ObjectForPool
    {
        [SerializeField] private int _countBlocks;
        [SerializeField] private int _chanceForSpawn;
        [SerializeField] private MainBlockFactory _factory;

        public int CountBlocks { get => _countBlocks; }
        public int ChanceForSpawn { get => _chanceForSpawn; }
        public MainBlockFactory Factory { get => _factory; }
    }

    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private List<ObjectForPool> _objectsForPool;
    [SerializeField] private Camera _mainCamera;

    private float _minPositionX;
    private float _maxPositionX;
    private float _maxPositionY;
    private float _minPositionY;

    private void Awake()
    {
        SetPoolMapForEachSpawnPoint(_spawnPoints);
    }

    private void SetRangePosition(SpawnPoint spawnPoints)
    {
        _minPositionX = _mainCamera.ViewportToWorldPoint(new Vector2(spawnPoints.SpawnPointScriptableObject.MinPositionX, 0)).x;
        _maxPositionX = _mainCamera.ViewportToWorldPoint(new Vector2(spawnPoints.SpawnPointScriptableObject.MaxPositionX, 0)).x;
        _minPositionY = _mainCamera.ViewportToWorldPoint(new Vector2(0, spawnPoints.SpawnPointScriptableObject.MinPositionY)).y;
        _maxPositionY = _mainCamera.ViewportToWorldPoint(new Vector2(0, spawnPoints.SpawnPointScriptableObject.MaxPositionY)).y;
    }
    private Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> GeneratePoolMap(List<ObjectForPool> objectsForPool, 
        SpawnPointScriptableObject spawnPointScriptableObject, SpawnPoint spawnPoint)
    {
        SetRangePosition(spawnPoint);

        Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> poolMap = new Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>>();

        foreach (var item in objectsForPool)
        {
            Queue<Block> pool = new Queue<Block>();

            for (int i = 0; i < item.CountBlocks; i++)
            {
                Vector3 startPositionBlock = new Vector3(Random.Range(_minPositionX, _maxPositionX), Random.Range(_minPositionY, _maxPositionY), 0);
                Block newBlock = item.Factory.GetBlock(startPositionBlock);
                newBlock.StartPosition = startPositionBlock;
                newBlock.SetMoveCharacter(spawnPointScriptableObject);
                newBlock.gameObject.SetActive(false);
                pool.Enqueue(newBlock);
            }

            poolMap.Add((pool.Peek().GetTag, item.ChanceForSpawn), pool);
        }

        return poolMap;
    }
    private void SetPoolMapForEachSpawnPoint(SpawnPoint[] spawnPoints)
    {
        foreach (var item in spawnPoints)
        {
            item.PoolMap = GeneratePoolMap(_objectsForPool, item.SpawnPointScriptableObject, item);
        }
    }
}
