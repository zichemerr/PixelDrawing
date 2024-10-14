using UnityEngine;

public class Drawing : MonoBehaviour
{
    [SerializeField] private Pixel[] _pixels;

    public void Init(ColorSelection colorSelection)
    {
        foreach (var pixels in _pixels)
            pixels.Init(colorSelection);
    }

    public void Disable()
    {
        foreach (var pixels in _pixels)
            pixels.Disable();
    }
}