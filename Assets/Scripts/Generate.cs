using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _minChild = 2;
    [SerializeField] private int _maxChild = 6;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _spawnJitter = 0.5f;

    [Header("Split Chance")]
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private float _childSplitMultiplier = 0.5f;
    [SerializeField] private float _minScale = 0.1f;

    [Header("Explosion Force")]
    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 10f;

    public void Boom()
    {
        float randomSplit = Random.value;

        Vector3 parentScale = transform.localScale;
        Vector3 parentPos = transform.position;
        Vector3 childScale = parentScale * _scaleFactor;

        if (transform.localScale.x < _minScale)
        {
            Destroy(gameObject);
            return;
        }

        if (randomSplit <= _splitChance)
        {
            int randomItemCount = Random.Range(_minChild, _maxChild + 1);

            List<Rigidbody> newCubesRigidbodies = new List<Rigidbody>();

            for (int i = 0; i < randomItemCount; i++)
            {
                Vector3 offset = Random.insideUnitSphere * _spawnJitter;

                GenerateNewObject(childScale, parentPos, offset, out Rigidbody rb);

                newCubesRigidbodies.Add(rb);
            }

            ApplyExplosion(newCubesRigidbodies, parentPos);

            Destroy(gameObject);            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void GenerateNewObject(Vector3 childScale, Vector3 parentPos, Vector3 offset, out Rigidbody newRigidbody)
    {
        float childSplitChance = _splitChance * _childSplitMultiplier;

        GameObject newObject = Instantiate(_prefab, parentPos, Quaternion.identity);

        newRigidbody = newObject?.GetComponent<Rigidbody>();
        Generate newChance = newObject?.GetComponent<Generate>();
        Renderer newRenderer = newObject?.GetComponent<Renderer>();

        if(newObject != null) 
            newObject.transform.localScale = childScale;

        if (newRenderer != null) 
            newRenderer.material.color = Random.ColorHSV();

        newChance?.SetSplitChance(childSplitChance);     
    }

    private void ApplyExplosion(List<Rigidbody> rigidBody, Vector3 explosionPosition)
    {
        foreach (Rigidbody rb in rigidBody)
        {
            rb?.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
        }
    }

    private void SetSplitChance(float newChance)
    {
        _splitChance = newChance;
    }
}
