using System.Collections.Generic;
using UnityEngine;

public class ChildsSpawner : MonoBehaviour
{
    [SerializeField] private CubeSplit cubePrefab;
    [SerializeField] private Colored _colored;

    [SerializeField] private float _childSplitMultiplier = 0.5f;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private int _multplierForce = 2;
    [SerializeField] private int _multiplierRadius = 2;
    [SerializeField] private int _minChild = 2;
    [SerializeField] private int _maxChild = 6;

    public List<Rigidbody> SpawnChildren(CubeSplit parentCube)
    {
        List<Rigidbody> childRigidbody = new List<Rigidbody>();

        Vector3 parentScale = parentCube.transform.localScale;
        Vector3 parentPos = parentCube.transform.position;
        Vector3 childScale = parentScale * _scaleFactor;

        float newSplitChance = parentCube.SplitChance * _childSplitMultiplier;
        float newForce = parentCube.ExplodeForce * _multplierForce;
        float newRadius = parentCube.ExplodeRadius * _multiplierRadius;

        int childCount = Random.Range(_minChild, _maxChild + 1);

        for (int i = 0; i < childCount; i++)
        {
            Rigidbody rigidbody = SpawnChildCube(parentPos, childScale, newSplitChance, newForce, newRadius);
            childRigidbody.Add(rigidbody);
        }

        return childRigidbody;
    }
    
    public void Despawn(CubeSplit cube)
    {
        Destroy(cube.gameObject);
    }

    private Rigidbody SpawnChildCube(Vector3 position, Vector3 scale, float newSplitChance, float newForce, float newRadius)
    {
        CubeSplit newCube = Instantiate(cubePrefab, position, Quaternion.identity);

        Color newColor = _colored.GetRandomColor();

        newCube.transform.localScale = scale;
        newCube.SetSplitChance(newSplitChance);
        newCube.ChangeExplodeSettings(newForce, newRadius);
        newCube.ApplyColor(newColor);

        return newCube.Rigidbody;

    }
}
