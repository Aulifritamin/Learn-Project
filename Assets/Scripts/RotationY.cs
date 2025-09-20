using UnityEngine;

public class RotationY : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed; 

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
