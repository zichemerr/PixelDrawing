using UnityEngine;

public class Level : MonoBehaviour
{
    private const string Color = nameof(Color);

    [SerializeField] private ColorSelection _colorSelection;
    [SerializeField] private Pixel[] _pixelColor;
    [SerializeField] private Pixel[] _draw;

    private DrawClean _drawClean;
    private DrawStart _drawStart;
    private Data _data;
    private ObjectSaving _saving;

    [Header("UI"), Space(2)]
    [SerializeField] private DrawStartView _drawView;
    [SerializeField] private LevelButton _nextButton;
    [SerializeField] private LevelButton _backButton;
    [SerializeField] private LevelButton _readyButton;

    private void Start()
    {
        _colorSelection.Init(_pixelColor);

        foreach (var drawPixel in _pixelColor)
            drawPixel.Init(_colorSelection);

        foreach (var draw in _draw)
            draw.Init(_colorSelection);

        _drawStart = new DrawStart(_pixelColor);
        _drawClean = new DrawClean(_draw);
        _data = new Data();
        _saving = new ObjectSaving();
    }

    private void OnEnable()
    {
        foreach (var pixelColor in _pixelColor)
            pixelColor.ColorChanged += OnColorChanged;

        _nextButton.Clicked += OnNexted;
        _backButton.Clicked += OnBacked;
        _readyButton.Clicked += OnReady;
    }

    private void OnDisable()
    {
        foreach (var pixelColor in _pixelColor)
            pixelColor.ColorChanged -= OnColorChanged;

        _nextButton.Clicked -= OnNexted;
        _backButton.Clicked -= OnBacked;
        _readyButton.Clicked -= OnReady;
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
        _readyButton.Enable();
        _drawView.Enable();
    }

    private void OnBacked()
    {
        _nextButton.Enable();
        _drawView.Disable();
        _backButton.Disable();
        _readyButton.Disable();
        _drawClean.Clear();
    }

    private void OnReady()
    {
        _data.Load(_draw, _pixelColor);
        _saving.Save(Color, _data);
    }
}
