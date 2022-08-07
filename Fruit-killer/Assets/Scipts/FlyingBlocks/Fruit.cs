using UnityEngine;

public class Fruit : Block
{
    [SerializeField] private ScriptableObjectBlock[] _blockCharacters;

    private void Start()
    {
        _mainCamera = Camera.main;
        SetVisualCharacterBlock(_blockCharacters[Random.Range(0, _blockCharacters.Length)]);
    }
    private void Update()
    {
        Move();
    }

    public override void Slice()
    {
        Debug.Log("Fruit sliced");
    }
}
