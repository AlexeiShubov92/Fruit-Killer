using UnityEngine;

public class BombFactory : MainBlockFactory
{
    [SerializeField] private Bomb _bombPrefab;
    public override Block GetBlock(Vector3 spawnPosition)
    {
        return Instantiate(_bombPrefab, spawnPosition, Quaternion.identity);
    }
}
