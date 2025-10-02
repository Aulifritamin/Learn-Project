using System.Collections.Generic;
using UnityEngine;

public class ChildImpulse : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 10f;

    public void AppleExplosion(List<Rigidbody> rigidbodies, Vector3 explosionPosition)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
        }
    }
}
