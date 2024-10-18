using System;
using UnityEngine;
using DG.Tweening;

public class AnimationStart
{
    private readonly Transform _transform;
    private readonly Vector2 _endPosition;
    private readonly float _duration;

    public event Action AnimationFinished;

    public AnimationStart(Transform transorm, Vector2 endPosition, float duration)
    {
        _transform = transorm;
        _endPosition = endPosition;
        _duration = duration;
    }

    public void Start()
    {
        _transform.DOLocalMoveX(_endPosition.x, _duration)
            .onComplete += () => AnimationFinished?.Invoke();
    }
}