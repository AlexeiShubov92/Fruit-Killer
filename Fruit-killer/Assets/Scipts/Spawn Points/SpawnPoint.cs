using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private SpawnPointScriptableObject _spawnPointScriptableObject;

    private Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> _poolMap;

    public void ActiveBlock(Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> poolMap, uint valueChance)
    {
        if (valueChance >= 100)
        {
            valueChance = 0;
        }

        List<(string, int)> keyList = new List<(string, int)>();

        foreach (var item in poolMap)
        {
            if (item.Key.ChanceForSpawn >= valueChance)
            {
                keyList.Add(item.Key);
            }
        }

        poolMap[keyList[Random.Range(0, keyList.Count)]].Peek().gameObject.SetActive(true);
    }
    public SpawnPointScriptableObject SpawnPointScriptableObject { get => _spawnPointScriptableObject; }
    public Dictionary<(string Tag, int ChanceForSpawn), Queue<Block>> PoolMap { get => _poolMap; set => _poolMap = value; }
}
