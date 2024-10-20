using UnityEngine;

public class ColorSelection : MonoBehaviour
{
    [SerializeField] private DrawingColor[] _colors;
    [SerializeField] private DrawingColor[] _drawColors;
    [SerializeField] private Border _border;

    public Color SelectedColor { get; private set; }

    public void Init()
    {
        foreach (var color in _colors)
            color.Init(OnSelected);

        foreach (var drawColors in _drawColors)
            drawColors.Init(OnSelected);
    }

    private void OnSelected(DrawingColor drawingColor)
    {
        SelectedColor = drawingColor.Color;
        _border.Activate(drawingColor.transform.position);
    }

    public void Clear()
    {
        SelectedColor = new Color();
    }
}
