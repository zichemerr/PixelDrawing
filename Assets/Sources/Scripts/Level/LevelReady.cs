using UnityEngine;

public class LevelReady : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonReady;

    private DrawStart _drawStart;
    private Pixel[] _draws;

    public void Init(Pixel[] draws)
    {
        _draws = draws;
        _drawStart = new DrawStart(draws, Color.gray);

        foreach (var draw in draws)
            draw.ColorChanged += OnDrawChanged;
    }

    private void OnEnable()
    {
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
        Debug.Log("Ready");
    }
}