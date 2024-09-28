using UnityEngine;

public class DrawClean
{
    private Pixel[] _pixels;
    private Color _cleanColor;

    public DrawClean(Pixel[] pixels)
    {
        _pixels = pixels;
        _cleanColor = Color.gray;
    }

    public void Clear()
    {
        foreach (var pixels in _pixels)
            pixels.SpriteRenderer.color = _cleanColor;
    }
}