using UnityEngine;

public class ColorLoader
{
    private Pixel[] _pixelColors;
    private SpriteRenderer[] _spriteRenderer;

    public ColorLoader(Pixel[] pixelColors, SpriteRenderer[] spriteRenderer)
    {
        _pixelColors = pixelColors;
        _spriteRenderer = spriteRenderer;
    }

    public void Load()
    {
        for (int i = 0; i < _pixelColors.Length; i++)
            _spriteRenderer[i].color = _pixelColors[i].Color;
    }
}