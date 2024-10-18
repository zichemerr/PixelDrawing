using UnityEngine;

public class ColorSelection : MonoBehaviour
{
    [SerializeField] private DrawingColor[] _colors;
    [SerializeField] private DrawingColor[] _drawColors;

    public Color SelectedColor { get; private set; }

    public void Init()
    {
        foreach (var color in _colors)
            color.Init(OnSelected);

        foreach (var drawColors in _drawColors)
            drawColors.Init(OnSelected);
    }

    private void OnSelected(Color color)
    {
        SelectedColor = color;
    }

    public void Clear()
    {
        SelectedColor = new Color();
    }
}
