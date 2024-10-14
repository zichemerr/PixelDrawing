using System;
using UnityEngine;

public class AnimationStart
{
    private readonly Transform _transform;
    private readonly Vector2 _endPosition;

    public event Action AnimationFinished;

    public AnimationStart(Transform transorm, Vector2 endPosition)
    {
        _transform = transorm;
        _endPosition = endPosition;
    }

    public void Start()
    {
        _transform.localPosition = _endPosition;
        AnimationFinished?.Invoke();
    }
}