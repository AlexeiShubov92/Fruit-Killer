using UnityEngine;

[CreateAssetMenu(menuName = "Create a Block", fileName = "Block")]
public class ScriptableObjectBlock : ScriptableObject
{
    [Header("Ñïğàéòû áëîêà")]
    [SerializeField] private Sprite _mainSpriteBlock;
    [SerializeField] private Sprite _leftBlock;
    [SerializeField] private Sprite _rightBlock;
    [SerializeField] private Sprite _splat;
    [Header("Öâåò êëÿêñû")]
    [SerializeField] private Color _colorSplat;
    [Header("Òıã áëîêà")]
    [SerializeField] private string _tag;
    [Header("Ğàçìåğ áëîêà")]
    [SerializeField] private float _scaleX;
    [SerializeField] private float _scaleY;

    public Sprite MainSpriteBlock { get => _mainSpriteBlock; }
    public Sprite LeftBlock { get => _leftBlock; }
    public Sprite RightBlock { get => _rightBlock; }
    public Sprite Splat { get => _splat; }
    public Color ColorSplat { get => _colorSplat; }
    public float ScaleX { get => _scaleX; }
    public float ScaleY { get => _scaleY; }
    public string Tag { get => _tag; }
}
