using UnityEngine;

public class LevelLoader
{
    private const string Color = nameof(Color);

    private SpriteRenderer[] _color;
    private SpriteRenderer[] _draw;
    private Data _data;

    public LevelLoader(SpriteRenderer[] draw, SpriteRenderer[] colors)
    {
        _draw = draw;
        _color = colors;
    }

    public void Load()
    {
        string json = PlayerPrefs.GetString(Color);
        _data = JsonUtility.FromJson<Data>(json);

        SetColor(_data.Colors, _color);
        SetColor(_data.Draw, _draw);
    }

    private void SetColor(Color[] colors, SpriteRenderer[] sprite)
    {
        for (int i = 0; i < sprite.Length; i++)
            sprite[i].color = colors[i];
    }
}
