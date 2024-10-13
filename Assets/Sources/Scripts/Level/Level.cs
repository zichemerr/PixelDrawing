using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonNext;
    [SerializeField] private LevelButton _buttonBack;
    [SerializeField] private LevelButton _buttonReady;
    [SerializeField] private DrawStartView _startView;

    private DrawStart _drawStart;
    private Pixel[] _pixelColors;

    public void Init(Pixel[] pixelColors)
    {
        _drawStart = new DrawStart(pixelColors, pixelColors[0].Color);
        _pixelColors = pixelColors;

        foreach (var pixelColor in _pixelColors)
            pixelColor.ColorChanged += OnReady;

        _buttonNext.Clicked += OnNext;
        _buttonBack.Clicked += OnBack;
    }

    private void OnDisable()
    {
        foreach (var pixelColor in _pixelColors)
            pixelColor.ColorChanged += OnReady;

        _buttonNext.Clicked -= OnNext;
        _buttonBack.Clicked -= OnBack;
    }

    private void OnReady()
    {
        if (_drawStart.CanStart() == false)
            return;

        _buttonNext.Enable();
    }

    private void OnNext()
    {
        _buttonNext.Disable();
        _startView.Enable();
        _buttonBack.Enable();
    }

    private void OnBack()
    {
        _buttonBack.Disable();
        _startView.Disable();
        _buttonNext.Enable();
        _buttonReady.Disable();
    }
}
