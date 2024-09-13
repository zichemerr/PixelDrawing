using UnityEngine;

public class ColorSelection : MonoBehaviour
{
    [SerializeField] private DrawingColor[] _colors;
    [SerializeField] private DrawingColor[] _drawColors;

    private SpriteRenderer[] _pixelSprites;
    private Pixel[] _pixels;

    public Color SelectedColor { get; private set; }

    public void Init(Pixel[] pixelColors)
    {
        SelectedColor = Color.white;
        _pixels = pixelColors;
        _pixelSprites = new SpriteRenderer[_drawColors.Length];

        foreach (var color in _colors)
            color.Init(Select);

        foreach (var drawColors in _drawColors)
            drawColors.Init(Select);

        for (int i = 0; i < _drawColors.Length; i++)
            _pixelSprites[i] = _drawColors[i].GetComponent<SpriteRenderer>();
    }

    public void SetColors()
    {
        for (int i = 0; i < _drawColors.Length; i++)
            _pixelSprites[i].color = _pixels[i].Color;
    }

    private void Select(Color color)
    {
        SelectedColor = color;
    }
}
