using UnityEngine;

public class DrawStartView : MonoBehaviour
{
    [SerializeField] private GameObject _colorMenu;
    [SerializeField] private GameObject _drawMenu;

    public void Enable()
    {
        _colorMenu.SetActive(false);
        _drawMenu.SetActive(true);
    }

    public void Disable()
    {
        _colorMenu.SetActive(true);
        _drawMenu.SetActive(false);
    }
}