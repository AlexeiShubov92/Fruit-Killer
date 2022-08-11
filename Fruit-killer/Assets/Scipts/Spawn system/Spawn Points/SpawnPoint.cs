using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private SpawnPointScriptableObject _spawnPointScriptableObject;

    private Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> _poolMap;
    private List<(string Tag, int ChanceForSpawn)> _keysWithMaxChanceForSpawn;

    private void Awake()
    {
        _keysWithMaxChanceForSpawn = GetKeysWithMaxChanceForSpawn(_poolMap);
    }

    private List<(string Tag, int ChanceForSpawn)> GetKeysWithMaxChanceForSpawn(Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> poolMap)
    {
        var temp = 0f;
        var result = new List<(string Tag, int ChanceForSpawn)>();

        foreach (var item in poolMap)
        {
            temp = item.Key.ChanceForSpawn > temp ? item.Key.ChanceForSpawn : temp;
        }

        foreach (var item in poolMap)
        {
            if (item.Key.ChanceForSpawn == temp)
            {
                result.Add(item.Key);
            }
        }

        return result;
    }

    public void ActiveBlock(Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> poolMap, int valueChance)
    {
        List <(string, int)> keyList = new List<(string, int)>();

        foreach (var item in poolMap)
        {
            if (item.Key.ChanceForSpawn >= valueChance)
            {
                keyList.Add(item.Key);
            }
        }

        keyList = keyList.Count == 0 ? _keysWithMaxChanceForSpawn : keyList;

        var key = keyList[Random.Range(0, keyList.Count)];
        var block = poolMap[key].Dequeue();
        block.gameObject.SetActive(true);
        _poolMap[key].Enqueue(block);
    }

    public SpawnPointScriptableObject SpawnPointScriptableObject { get => _spawnPointScriptableObject; }
    public Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> PoolMap { get => _poolMap; set => _poolMap = value; }
}
