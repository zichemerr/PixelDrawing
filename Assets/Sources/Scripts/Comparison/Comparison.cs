using UnityEngine;

public class Comparison
{
    private readonly Pixel[] _firstDrawing;
    private readonly Pixel[] _secondDrawing;

    public Comparison(Pixel[] firstDrawing, Pixel[] secondDrawing)
    {
        _firstDrawing = firstDrawing;
        _secondDrawing = secondDrawing;
    }

    public bool CheckCompare()
    {
        for (int i = 0; i < _firstDrawing.Length; i++)
            if (_firstDrawing[i].Color != _secondDrawing[i].Color)
                return false;

        return true;
    }
}
