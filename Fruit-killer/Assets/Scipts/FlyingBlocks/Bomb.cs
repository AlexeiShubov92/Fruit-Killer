using UnityEngine;

public class Bomb : Block
{
    [SerializeField] private ScriptableObjectBlock _bombCharacter;

    private void Start()
    {
        _mainCamera = Camera.main;
        SetVisualCharacterBlock(_bombCharacter);
    }
    private void Update()
    {
        Move();
        BlockOffScreen(_mainCamera);
    }

    public override void Slice()
    {
        Debug.LogError("Bomb sliced");
    }
}
