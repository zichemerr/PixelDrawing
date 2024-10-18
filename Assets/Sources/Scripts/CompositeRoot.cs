using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Level _level;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private LevelCleaner _levelCleaner;
    [SerializeField] private LevelReady _levelReady;
    [SerializeField] private Drawing _secondDraw;
    [SerializeField] private Drawing _firstDraw;
    [SerializeField] private Drawing _pixelColor;
    [SerializeField] private ComparisonRoot _comparisonRoot;
    [SerializeField] private LevelRestart _levelRestart;

    private void Start()
    {
        _colorSelection.Init();
        _secondDraw.Init(_colorSelection);
        _firstDraw.Init(_colorSelection);
        _pixelColor.Init(_colorSelection);
        _level.Init(_pixelColor);
        _levelLoader.Init(_pixelColor);
        _levelCleaner.Init(_levelLoader, _colorSelection, _secondDraw);
        _levelReady.Init(_secondDraw);
        _comparisonRoot.Init(_firstDraw, _secondDraw);
        _levelRestart.Init(_comparisonRoot);
    }
}
