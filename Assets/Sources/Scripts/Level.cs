using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Pixel[] _pixelColor;
    [SerializeField] private Pixel[] _draw;

    private DrawClean _drawClean;
    private DrawStart _drawStart;

    [Header("UI"), Space(2)]
    [SerializeField] private DrawStartView _drawView;
    [SerializeField] private LevelButton _nextButton;
    [SerializeField] private LevelButton _backButton;

    private void Start()
    {
        _colorSelection.Init(_pixelColor);

        foreach (var drawPixel in _pixelColor)
            drawPixel.Init(_colorSelection);

        _drawStart = new DrawStart();
        _drawStart.Init(_pixelColor);

        foreach (var draw in _draw)
            draw.Init(_colorSelection);

        _drawClean = new DrawClean(_draw);
        _drawClean.Init();
    }

    private void OnEnable()
    {
        foreach (var pixelColor in _pixelColor)
            pixelColor.ColorChanged += OnColorChanged;

        _nextButton.Clicked += OnNexted;
        _backButton.Clicked += OnBacked;
    }

    private void OnDisable()
    {
        foreach (var pixelColor in _pixelColor)
            pixelColor.ColorChanged -= OnColorChanged;

        _nextButton.Clicked -= OnNexted;
        _backButton.Clicked -= OnBacked;
    }

    private void OnColorChanged()
    {
        if (_drawStart.CanStart() == false)
            return;

        _nextButton.Enable();
    }

    private void OnNexted()
    {
        _colorSelection.SetColors();
        _backButton.Enable();
        _nextButton.Disable();
        _drawView.Enable();
    }

    private void OnBacked()
    {
        _nextButton.Enable();
        _drawView.Disable();
        _backButton.Disable();
        _drawClean.Clear();
    }
}
