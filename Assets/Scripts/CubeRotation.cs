using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] Transform cubeTransform;
    [SerializeField] float rotationSpeed; 

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        cubeTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
