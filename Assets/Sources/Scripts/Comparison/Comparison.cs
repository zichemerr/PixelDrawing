using UnityEngine;

public class Comparison
{
    public bool CheckCompare(Color[] firstDrawing, Color[] secondDrawing)
    {
        for (int i = 0; i < firstDrawing.Length; i++)
            if (firstDrawing[i] != secondDrawing[i])
                return false;

        return true;
    }
}
