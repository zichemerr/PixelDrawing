using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonNext;
    [SerializeField] private SpriteRenderer[] _colorSprites;

    private ColorLoader _colorLoader;

    public event Action Loaded;

    public void Init(Pixel[] pixelColors)
    {
        _colorLoader = new ColorLoader(pixelColors, _colorSprites);
        _buttonNext.Clicked += OnLoad;
    }

    private void OnDisable()
    {
        _buttonNext.Clicked -= OnLoad;
    }

    private void OnLoad()
    {
        _colorLoader.Load();
        Loaded?.Invoke();
    }
}
