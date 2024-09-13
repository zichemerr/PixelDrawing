using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class DrawingColor : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Action<Color> _selectAction;

    public void Init(Action<Color> celectAction)
    {
        _sprite = GetComponent<SpriteRenderer>();
        _selectAction = celectAction;
    }

    private void OnMouseDown()
    {
        _selectAction?.Invoke(_sprite.color);
    }
}
