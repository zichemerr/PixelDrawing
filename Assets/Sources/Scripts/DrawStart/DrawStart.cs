using UnityEngine;

public class DrawStart
{
    private readonly Color _defaultColor;

    public DrawStart(Color defaultColor)
    {
        _defaultColor = defaultColor;
    }

    public bool CanStart(Color[] colors)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i] == _defaultColor)
                return false;
        }

        return true;
    }
}
