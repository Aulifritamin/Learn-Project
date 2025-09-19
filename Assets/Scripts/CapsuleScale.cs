using UnityEngine;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField] private Transform capsuleTransform;
    [SerializeField] private float scaleSpeed;

    private void Update()
    {
        Grow();
    }

    private void Grow()
    {
        float growSpeed = scaleSpeed * Time.deltaTime;

        capsuleTransform.localScale += new Vector3(growSpeed, growSpeed, growSpeed);
    }
}
