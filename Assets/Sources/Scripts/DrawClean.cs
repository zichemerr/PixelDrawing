using UnityEngine;

public class DrawClean
{
    private Pixel[] _pixels;
    private SpriteRenderer[] _spriteRenderers;
    private Color _defalutColor;

    public DrawClean(Pixel[] pixels)
    {
        _pixels = pixels;
        _defalutColor = Color.gray;
        _spriteRenderers = new SpriteRenderer[pixels.Length];

    }

    public void Init()
    {
        for (int i = 0; i < _pixels.Length; i++)
            _spriteRenderers[i] = _pixels[i].GetComponent<SpriteRenderer>();
    }

    public void Clear()
    {
        foreach (var spriteRenderers in _spriteRenderers)
            spriteRenderers.color = _defalutColor;
    }
}