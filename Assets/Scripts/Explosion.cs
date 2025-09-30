using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 10f;

    public void AppleExplosion(List<Rigidbody> rigidbodies, Vector3 explosionPosition)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
        }
    }
}
