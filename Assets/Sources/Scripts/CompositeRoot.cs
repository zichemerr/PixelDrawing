using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Level _level;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private LevelCleaner _levelCleaner;
    [SerializeField] private LevelReady _levelReady;
    [SerializeField] private Drawing _drawing;
    [SerializeField] private Drawing _firstDraw;
    [SerializeField] private Drawing _pixelColor;

    private void Start()
    {
        _colorSelection.Init();
        _drawing.Init(_colorSelection);
        _firstDraw.Init(_colorSelection);
        _pixelColor.Init(_colorSelection);
        _level.Init(_pixelColor);
        _levelLoader.Init(_pixelColor);
        _levelCleaner.Init(_levelLoader, _colorSelection, _drawing);
        _levelReady.Init(_drawing);
    }
}
