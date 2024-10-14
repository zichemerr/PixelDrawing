using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonNext;
    [SerializeField] private SpriteRenderer[] _colorSprites;

    private ColorLoader _colorLoader;
    private Drawing _pixelColors;

    public event Action Loaded;

    public void Init(Drawing pixelColors)
    {
        _pixelColors = pixelColors;
        _colorLoader = new ColorLoader(_colorSprites);
        _buttonNext.Clicked += OnLoad;
    }

    private void OnDisable()
    {
        _buttonNext.Clicked -= OnLoad;
    }

    private void OnLoad()
    {
        _colorLoader.Load(_pixelColors.GetColors());
        Loaded?.Invoke();
    }
}
