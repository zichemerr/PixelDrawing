using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Level _level;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private LevelCleaner _levelCleaner;
    [SerializeField] private LevelReady _levelReady;

    [SerializeField] private Pixel[] _draw;
    [SerializeField] private Pixel[] _pixelColors;

    private void Start()
    {
        _colorSelection.Init();

        foreach (var draw in _draw)
            draw.Init(_colorSelection);

        foreach (var pixelColors in _pixelColors)
            pixelColors.Init(_colorSelection);

        _level.Init(_pixelColors);
        _levelLoader.Init(_pixelColors);
        _levelCleaner.Init(_levelLoader, _colorSelection, _draw);
        _levelReady.Init(_draw);
    }
}
