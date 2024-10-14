using UnityEngine;

public class LevelReady : MonoBehaviour
{
    [SerializeField] private LevelStart _levelStart;
    [SerializeField] private LevelButton _buttonReady;

    private DrawStart _drawStart;
    private Drawing _secondDrawing;

    public void Init(Drawing secondDrawing)
    {
        _secondDrawing = secondDrawing;
        _drawStart = new DrawStart(Color.gray);
        _levelStart.Init();

        _secondDrawing.Changed += OnDrawChanged;
        _buttonReady.Clicked += OnReady;
    }

    private void OnDisable()
    {
        _secondDrawing.Changed -= OnDrawChanged;
        _buttonReady.Clicked -= OnReady;
    }

    private void OnDrawChanged()
    {
        if (_drawStart.CanStart(_secondDrawing.GetColors()) == false)
        {
            Debug.Log("Почему так?");
            return;
        }

        _buttonReady.Enable();
    }

    private void OnReady()
    {
        _buttonReady.Disable();
        _secondDrawing.Disable();
        _levelStart.StartLevel();
    }
}
