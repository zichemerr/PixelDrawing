using System;
using UnityEngine;

public class ComparisonRoot : MonoBehaviour
{
    private Comparison _comparison;
    private Pixel[] _secondDrawing;

    public event Action Finished;

    public void Init(Pixel[] firstDrawing, Pixel[] secondDrawing)
    {
        _secondDrawing = secondDrawing;
        _comparison = new Comparison(firstDrawing, secondDrawing);

        foreach (var secondDrawings in _secondDrawing)
            secondDrawings.ColorChanged += OnColorChanged;
    }

    private void OnDisable()
    {
        foreach (var secondDrawings in _secondDrawing)
            secondDrawings.ColorChanged -= OnColorChanged;
    }

    private void OnColorChanged()
    {
        if (_comparison.CheckCompare())
            Finished?.Invoke();
    }
}
