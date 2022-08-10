using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int _delayForSpawn;
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private List<SpawnPoint> _spawnPointsWithTheBestChanceForSpawn;

    private void Start()
    {
        _spawnPointsWithTheBestChanceForSpawn = GetSpawnPointsWithMaxChanceForSpawn(_spawnPoints);
        RunObject(GetSpawnPointForSpawn(_spawnPoints, _spawnPointsWithTheBestChanceForSpawn), _delayForSpawn);
    }

    private List<SpawnPoint> GetSpawnPointsWithMaxChanceForSpawn(SpawnPoint[] spawnPoints)
    {
        var temp = 0f;
        var result = new List<SpawnPoint>();

        foreach (var item in spawnPoints)
        {
            temp = item.SpawnPointScriptableObject.Chance > temp ? item.SpawnPointScriptableObject.Chance : temp;
        }

        foreach (var item in spawnPoints)
        {
            if(item.SpawnPointScriptableObject.Chance == temp)
            {
                result.Add(item);
            }
        }

        return result;
    }
    private SpawnPoint GetSpawnPointForSpawn(SpawnPoint[] spawnPoints, List<SpawnPoint> spawnPointsWithTheBestChanceForSpawn)
    {
        var random = Random.Range(0, 101);
        var result = new List<SpawnPoint>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].SpawnPointScriptableObject.Chance >= random)
            {
                result.Add(spawnPoints[i]);
            }
        }

        result = result.Count == 0 ? spawnPointsWithTheBestChanceForSpawn : result;

        return result[Random.Range(0, result.Count)];
    }
    private async void RunObject(SpawnPoint spawnPoint, int delayForSpawn)
    {
        spawnPoint.ActiveBlock(spawnPoint.PoolMap, Random.Range(0, 101));

        await Task.Delay(delayForSpawn);

        RunObject(GetSpawnPointForSpawn(_spawnPoints, _spawnPointsWithTheBestChanceForSpawn), _delayForSpawn);
    }

































    //[SerializeField] SpawnPoint[] _spawnPoints;

    //private SpawnPoint[] _haveBestChanceForChoose;

    //private void Start()
    //{
    //    _haveBestChanceForChoose = GetBestChanceForChoose(_spawnPoints);
    //    RunObject(ChooseSpawnPoint(_spawnPoints, _haveBestChanceForChoose));
    //}

    //private SpawnPoint[] GetBestChanceForChoose(SpawnPoint[] spawnPoints)
    //{
    //    float bestChance = spawnPoints.Max(t => t.SpawnPointScriptableObject.Chance);

    //    return spawnPoints.Where(t => t.SpawnPointScriptableObject.Chance == bestChance).ToArray();
    //}
    //private SpawnPoint ChooseSpawnPoint(SpawnPoint[] spawnPoints, SpawnPoint[] haveBestChanceForChoose)
    //{
    //    float randomChance = Random.Range(0, 101);

    //    SpawnPoint[] bestChanceForChoose = spawnPoints.Where(t => t.SpawnPointScriptableObject.Chance >= randomChance).ToArray();

    //    if(bestChanceForChoose.Count() == 0)
    //    {
    //        bestChanceForChoose = haveBestChanceForChoose;
    //    }

    //    return bestChanceForChoose.ToArray()[Random.Range(0, bestChanceForChoose.Count())];
    //}
}
