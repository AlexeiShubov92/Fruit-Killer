using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [Header("Objects for sprites of the block")]
    [SerializeField] protected SpriteRenderer _mainSpriteBlock;
    [SerializeField] protected SpriteRenderer _leftBlock;
    [SerializeField] protected SpriteRenderer _rightBlock;
    [SerializeField] protected SpriteRenderer _splat;

    protected Camera _mainCamera;
    protected Color _colorSplat;
    protected Vector2 _direction;

    protected float _startSpeedX;
    protected float _stepSpeedX;
    protected float _startSpeedY;
    protected float _stepSpeedY;

    protected void SetVisualCharacterBlock(ScriptableObjectBlock blockData)
    {
        _mainSpriteBlock.sprite = blockData.MainSpriteBlock;
        _rightBlock.sprite = blockData.RightBlock;
        _leftBlock.sprite = blockData.LeftBlock;
        _colorSplat = blockData.ColorSplat;
        _splat.sprite = blockData.Splat;
        _splat.color = blockData.ColorSplat;
        tag = blockData.Tag;

        transform.localScale = new Vector2(blockData.ScaleX, blockData.ScaleY);
    }
    protected void BlockOffScreen(Camera mainCamera)
    {
        if (_direction.y < 0 && transform.position.y < -mainCamera.orthographicSize * 2)
        {
            transform.position = StartPosition;
            _direction = new Vector2(_startSpeedX, _startSpeedY);
            gameObject.SetActive(false);
        }
    }

    protected void Move()
    {
        transform.Translate(_direction * Time.deltaTime);
        _direction -= new Vector2(_stepSpeedX, _stepSpeedY) * Time.deltaTime;

        BlockOffScreen(_mainCamera);
    }

    public void SetMoveCharacter(SpawnPointScriptableObject spawnPoint)
    {
        _startSpeedX = spawnPoint.StartSpeedX * -transform.position.x;
        _stepSpeedX = spawnPoint.StepSpeedX * -transform.position.x;

        _startSpeedY = transform.position.y <= 0 ? (spawnPoint.StartSpeedY + (-0.5f * transform.position.y))
            : (spawnPoint.StartSpeedY - transform.position.y);
        _stepSpeedY = spawnPoint.StepSpeedY;

        _direction = new Vector2(_startSpeedX, _startSpeedY);
    }
    public abstract void Slice();

    public Vector3 StartPosition { get; set; }
    public string GetTag { get => tag; }
}
