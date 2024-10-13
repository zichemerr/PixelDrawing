using UnityEngine;

public class DrawStart
{
    private Pixel[] _drawPixels;
    private Color _defaultColor;

    public DrawStart(Pixel[] drawPixels, Color defaultColor)
    {
        _drawPixels = drawPixels;
        _defaultColor = defaultColor;
    }

    public bool CanStart()
    {
        foreach (var drawPixels in _drawPixels)
            if (drawPixels.Color == _defaultColor)
                return false;

        return true;
    }
}
