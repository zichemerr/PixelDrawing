using System;
using UnityEngine;

public class Drawing : MonoBehaviour, IClean
{
    [SerializeField] private Pixel[] _pixels;

    public event Action Changed;

    public void Init(ColorSelection colorSelection)
    {
        foreach (var pixels in _pixels)
            pixels.Init(colorSelection);
    }

    private void OnEnable()
    {
        foreach (var pixel in _pixels)
            pixel.ColorChanged += OnColorChanged;
    }

    private void OnDisable()
    {
        foreach (var pixel in _pixels)
            pixel.ColorChanged -= OnColorChanged;
    }

    private void OnColorChanged()
    {
        Changed?.Invoke();
    }

    public Color[] GetColors()
    {
        Color[] color = new Color[_pixels.Length];

        for (int i = 0; i < _pixels.Length; i++)
            color[i] = _pixels[i].Color;

        return color;
    }

    public Color GetColor(int index)
    {
        return _pixels[index].Color;
    }

    public void Disable()
    {
        foreach (var pixels in _pixels)
            pixels.Disable();
    }

    public void Clear()
    {
        foreach (var pixel in _pixels)
            pixel.Clear();
    }
}