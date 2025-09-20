using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    private void Update()
    {
        Grow();
    }

    private void Grow()
    {
        float growSpeed = _scaleSpeed * Time.deltaTime;

        transform.localScale += new Vector3(growSpeed, growSpeed, growSpeed);
    }
}
