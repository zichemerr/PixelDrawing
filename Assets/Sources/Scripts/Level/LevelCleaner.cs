using UnityEngine;

public class LevelCleaner : MonoBehaviour
{
    private ColorSelection _colorSelection;
    private LevelLoader _levelLoader;
    private IClean _secondDraw;

    public void Init(LevelLoader levelLoader,
        ColorSelection colorSelection, IClean secondDraw)
    {
        _levelLoader = levelLoader;
        _colorSelection = colorSelection;
        _secondDraw = secondDraw;
        _levelLoader.Loaded += OnClean;
    }

    private void OnDisable()
    {
        _levelLoader.Loaded -= OnClean;
    }

    private void OnClean()
    {
        _colorSelection.Clear();
        _secondDraw.Clear();
    }
}
