using UnityEngine;

public class ColorLoader
{
    private SpriteRenderer[] _spriteRenderer;

    public ColorLoader(SpriteRenderer[] spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }

    public void Load(Color[] colors)
    {
        for (int i = 0; i < colors.Length; i++)
            _spriteRenderer[i].color = colors[i];
    }
}