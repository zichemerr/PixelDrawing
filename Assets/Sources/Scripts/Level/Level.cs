using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonNext;
    [SerializeField] private LevelButton _buttonBack;
    [SerializeField] private LevelButton _buttonReady;
    [SerializeField] private DrawStartView _startView;

    private Drawing _drawingColor;
    private DrawStart _drawStart;

    public void Init(Drawing drawingColor)
    {
        _drawingColor = drawingColor;
        _drawStart = new DrawStart(_drawingColor.GetColor(0));

        _drawingColor.Changed += OnReady;
        _buttonNext.Clicked += OnNext;
        _buttonBack.Clicked += OnBack;
    }

    private void OnDisable()
    {
        _drawingColor.Changed -= OnReady;
        _buttonNext.Clicked -= OnNext;
        _buttonBack.Clicked -= OnBack;
    }

    private void OnReady()
    {
        if (_drawStart.CanStart(_drawingColor.GetColors()) == false)
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
