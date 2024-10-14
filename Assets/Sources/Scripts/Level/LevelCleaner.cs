using UnityEngine;

public class LevelCleaner : MonoBehaviour
{
    private ColorSelection _colorSelection;
    private LevelLoader _levelLoader;
    private IClean _clean;

    public void Init(LevelLoader levelLoader, ColorSelection colorSelection, IClean clean)
    {
        _levelLoader = levelLoader;
        _colorSelection = colorSelection;
        _clean = clean;
        _levelLoader.Loaded += OnClean;
    }

    private void OnDisable()
    {
        _levelLoader.Loaded -= OnClean;
    }

    private void OnClean()
    {
        _colorSelection.Clear();
        _clean.Clear();
    }
}
