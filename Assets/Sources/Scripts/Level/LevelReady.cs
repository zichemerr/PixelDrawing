using UnityEngine;

public class LevelReady : MonoBehaviour
{
    [SerializeField] private LevelStart _levelStart;
    [SerializeField] private LevelButton _buttonReady;

    private DrawStart _drawStart;
    private Pixel[] _draws;
    private Drawing _secondDrawing;

    public void Init(Pixel[] draws, Drawing secondDrawing)
    {
        _draws = draws;
        _secondDrawing = secondDrawing;
        _drawStart = new DrawStart(draws, Color.gray);

        foreach (var draw in draws)
            draw.ColorChanged += OnDrawChanged;

        _levelStart.Init();
        _buttonReady.Clicked += OnReady;
    }

    private void OnDisable()
    {
        _buttonReady.Clicked -= OnReady;

        foreach (var draw in _draws)
            draw.ColorChanged -= OnDrawChanged;
    }

    private void OnDrawChanged()
    {
        if (_drawStart.CanStart() == false)
            return;

        _buttonReady.Enable();
    }

    private void OnReady()
    {
        _buttonReady.Disable();
        _secondDrawing.Disable();
        _levelStart.StartLevel();
    }
}
