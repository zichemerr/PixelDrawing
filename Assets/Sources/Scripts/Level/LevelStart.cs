﻿using UnityEngine;

public class LevelStart : MonoBehaviour
{
    [SerializeField] private GameObject _firstDraw;
    [SerializeField] private Transform _secondDraw;
    [SerializeField] private Vector2 _endPosition;
    [SerializeField] private float _duration;

    private AnimationStart _animation;

    public void Init()
    {
        _animation = new AnimationStart(_secondDraw, _endPosition, _duration);
        _animation.AnimationFinished += OnFinished;
    }

    private void OnDisable()
    {
        _animation.AnimationFinished -= OnFinished;
    }

    private void OnFinished()
    {
        _firstDraw.SetActive(true);
    }

    public void StartLevel()
    {
        _animation.Start();
    }
}
