using UnityEngine;

public class Border : MonoBehaviour
{
    public void Activate(Vector2 point)
    {
        gameObject.SetActive(true);
        transform.position = point;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
