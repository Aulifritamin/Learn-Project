using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private Transform cubeTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float scaleSpeed;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveSpeed = this.moveSpeed * Time.deltaTime;

        cubeTransform.Translate(Vector3.forward * moveSpeed);
        cubeTransform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        cubeTransform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
    }
}
