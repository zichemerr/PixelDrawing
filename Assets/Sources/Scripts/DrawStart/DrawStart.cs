using UnityEngine;

public class DrawStart
{
    private Pixel[] _drawPixels;
    private Color _defaultColor;

    public void Init(Pixel[] drawPixels)
    {
        _drawPixels = drawPixels;
        _defaultColor = _drawPixels[0].Color;
    }

    public bool CanStart()
    {
        foreach (var drawPixels in _drawPixels)
            if (drawPixels.Color == _defaultColor)
                return false;

        return true;
    }
}
