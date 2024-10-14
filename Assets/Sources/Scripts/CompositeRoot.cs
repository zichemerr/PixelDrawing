using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Level _level;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private LevelCleaner _levelCleaner;
    [SerializeField] private LevelReady _levelReady;

    [SerializeField] private Pixel[] _draw;
    [SerializeField] private Drawing _drawing;
    [SerializeField] private Pixel[] _firstDraw;
    [SerializeField] private Pixel[] _pixelColors;

    private void Start()
    {
        _colorSelection.Init();
        _drawing.Init(_colorSelection);

        foreach (var firstDraw in _firstDraw)
            firstDraw.Init(_colorSelection);

        foreach (var pixelColors in _pixelColors)
            pixelColors.Init(_colorSelection);

        _level.Init(_pixelColors);
        _levelLoader.Init(_pixelColors);
        _levelCleaner.Init(_levelLoader, _colorSelection, _draw);
        _levelReady.Init(_draw, _drawing);
    }
}
