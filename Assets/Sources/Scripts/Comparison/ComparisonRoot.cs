using System;
using UnityEngine;

public class ComparisonRoot : MonoBehaviour
{
    private Drawing _firstDrawing;
    private Drawing _secondDrawing;
    private Comparison _comparison;

    public event Action Finished;

    public void Init(Drawing firstDrawing, Drawing secondDrawing)
    {
        _comparison = new Comparison();
        _firstDrawing = firstDrawing;
        _secondDrawing = secondDrawing;

        _firstDrawing.Changed += OnDrawChanged;
    }

    private void OnDisable()
    {
        _firstDrawing.Changed -= OnDrawChanged;
    }

    private void OnDrawChanged()
    {
        if (_comparison.CheckCompare(_firstDrawing.GetColors(), _secondDrawing.GetColors()))
            Finished?.Invoke();
    }
}
