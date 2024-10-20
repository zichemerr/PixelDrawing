using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Pixel : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ColorSelection _colorSelection;

    public Color Color => _spriteRenderer.color;

    public event Action ColorChanged;

    public bool IsActive { get; private set; } = true;

    public void Init(ColorSelection colorSelection)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _colorSelection = colorSelection;
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
            SetColor(_colorSelection.SelectedColor);
    }

    private void OnMouseDown()
    {
        SetColor(_colorSelection.SelectedColor);
    }

    private void SetColor(Color color)
    {
        if (IsActive == false || color == new Color())
            return;

        _spriteRenderer.color = color;
        ColorChanged?.Invoke();
    }

    public void Clear()
    {
        _spriteRenderer.color = Color.gray;
    }

    public void Disable()
    {
        IsActive = false;
    }
}
