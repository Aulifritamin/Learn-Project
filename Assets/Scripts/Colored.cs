using UnityEngine;

public class Colored : MonoBehaviour
{
    public void ChangeColor(CubeSplit cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        
        if (renderer != null)
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
