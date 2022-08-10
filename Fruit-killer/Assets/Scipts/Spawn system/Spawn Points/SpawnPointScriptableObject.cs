using UnityEngine;

[CreateAssetMenu(menuName = "Create Spawn Point", fileName = "SpawnPoint")]
public class SpawnPointScriptableObject : ScriptableObject
{
    [Header("Range for spawn")]
    [SerializeField][Range(0f, 1f)] private float _minPointToSpawnForX;
    [SerializeField][Range(0f, 1f)] private float _maxPointToSpawnForX;
    [SerializeField][Range(0f, 1f)] private float _minPointToSpawnForY;
    [SerializeField][Range(0f, 1f)] private float _maxPointToSpawnForY;
    [Header("Range of speed a block")]
    [SerializeField][Range(0f, 20f)] private float _minStartSpeedX;
    [SerializeField][Range(0f, 20f)] private float _maxStartSpeedX;
    [SerializeField][Range(0f, 20f)] private float _minStartSpeedY;
    [SerializeField][Range(0f, 20f)] private float _maxStartSpeedY;
    [Header("Speed reduction factor")]
    [SerializeField][Range(0.01f, 1f)] private float _stepSpeedX;
    [SerializeField][Range(0.001f, 20f)] private float _stepSpeedY;
    [Header("Probability of choosing the Spawn Point to spawn")]
    [SerializeField][Range(0, 100)] private float _chance;

    private float _startSpeedX;
    private float _startSpeedY;

    public float MinPositionX { get => _minPointToSpawnForX; }
    public float MaxPositionX { get => _maxPointToSpawnForX; }
    public float MinPositionY { get => _minPointToSpawnForY; }
    public float MaxPositionY { get => _maxPointToSpawnForY; }
    public float StartSpeedX
    { 
        get
        {
            if(_minStartSpeedX >= _maxStartSpeedX)
            {
                return _startSpeedX = _minStartSpeedX;
            }

            return _startSpeedX = Random.Range(_minStartSpeedX, _maxStartSpeedX);
        }
    }
    public float StepSpeedX { get => _stepSpeedX; }
    public float StartSpeedY 
    {
        get
        {
            if (_minStartSpeedY >= _maxStartSpeedY)
            {
                return _startSpeedY = _minStartSpeedY;
            }

            return _startSpeedY = Random.Range(_minStartSpeedY, _maxStartSpeedY);
        }
    }
    public float StepSpeedY { get => _stepSpeedY; }
    public float Chance { get => _chance; }
}
