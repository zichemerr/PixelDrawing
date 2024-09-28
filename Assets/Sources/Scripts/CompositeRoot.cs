using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Pixel[] _secondDraw;
    [SerializeField] private SpriteRenderer[] _color;
    [SerializeField] private SpriteRenderer[] _draw;

    private LevelLoader _levelLoader;

    private void Start()
    {
        _levelLoader = new LevelLoader(_draw, _color);
        _levelLoader.Load();

        _colorSelection.Init();

        foreach (var drawPixel in _secondDraw)
            drawPixel.Init(_colorSelection);
    }
}
