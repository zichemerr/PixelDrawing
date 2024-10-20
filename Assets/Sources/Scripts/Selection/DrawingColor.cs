using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class DrawingColor : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Action<DrawingColor> _selectAction;

    public Color Color => _sprite.color;

    public void Init(Action<DrawingColor> celectAction)
    {
        _sprite = GetComponent<SpriteRenderer>();
        _selectAction = celectAction;
    }

    private void OnMouseDown()
    {
        _selectAction?.Invoke(this);
    }
}
