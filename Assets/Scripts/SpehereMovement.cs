using UnityEngine;

public class SpehereMovement : MonoBehaviour
{
    [SerializeField] private Transform transform;
    [SerializeField] float speed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
