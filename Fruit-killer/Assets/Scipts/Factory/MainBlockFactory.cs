using UnityEngine;

public abstract class MainBlockFactory : MonoBehaviour
{
    public abstract Block GetBlock(Vector3 spawnPosition);
}
