using Michsky.MUIP;
using System;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private ButtonManager _button;

    public event Action Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Clicked?.Invoke();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
