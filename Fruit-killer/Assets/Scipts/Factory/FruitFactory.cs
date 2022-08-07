using UnityEngine;

public class FruitFactory : MainBlockFactory
{
    [SerializeField] private Fruit _fruitPrefab;

    public override Block GetBlock(Vector3 spawnPosition)
    {
        return Instantiate(_fruitPrefab, spawnPosition, Quaternion.identity);
    }
}
