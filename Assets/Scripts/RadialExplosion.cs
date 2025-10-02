using System.Collections.Generic;
using UnityEngine;

public class RadialExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private float _upwardsModifier = 0f;
    [SerializeField] private ForceMode _forceMode = ForceMode.VelocityChange;

    private float _destroingTime = 1.5f;

    public void Boom(CubeSplit cube)
    {
        Vector3 parentPosition = cube.transform.position;

        if (_explosionEffect != null)
        {
            ParticleSystem explodeEffect = Instantiate(_explosionEffect, parentPosition, Quaternion.identity);
            explodeEffect.Play();

            Destroy(explodeEffect.gameObject, _destroingTime);
        }

        Collider[] colliders = Physics.OverlapSphere(parentPosition, cube.ExplodeRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;

            if (rb == null) continue;

            if (rb == cube.Rigidbody) continue;

            rb.AddExplosionForce(cube.ExplodeForce, parentPosition, cube.ExplodeRadius, _upwardsModifier, _forceMode);
        }
    }
}
