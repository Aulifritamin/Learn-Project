using UnityEngine;

public class Colored : MonoBehaviour
{

    public Color GetRandomColor()
    {
        return Random.ColorHSV();
    }
}
