using UnityEngine;

public class Data
{
    public Color[] Draw;
    public Color[] Colors;

    public void Load(Pixel[] draw, Pixel[] colors)
    {
        LoadColors(ref Draw, draw);
        LoadColors(ref Colors, colors);
    }

    private void LoadColors(ref Color[] color, Pixel[] pixel)
    {
        color = new Color[pixel.Length];

        for (int i = 0; i < pixel.Length; i++)
            color[i] = pixel[i].Color;
    }
}