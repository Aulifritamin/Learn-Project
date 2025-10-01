using System;
using System.Collections.Generic;
using UnityEngine;

public class ChildsSpawner : MonoBehaviour
{
    [SerializeField] private CubeSplit cubePrefab;
    [SerializeField] private Colored _colored;


    public List<Rigidbody> ChildSpawn(CubeSplit parentCube, float splitChance, int childCount, float scaleFactor)
    {
        List<Rigidbody> childRigidbody = new List<Rigidbody>();

        Vector3 parentScale = parentCube.transform.localScale;
        Vector3 parentPos = parentCube.transform.position;
        Vector3 childScale = parentScale * scaleFactor;

        float newSplitChance = parentCube.SplitChance * splitChance;

        for (int i = 0; i < childCount; i++)
        {
            Rigidbody rigidbody = SpawnChildCube(parentPos, childScale, newSplitChance);
            childRigidbody.Add(rigidbody);
        }

        return childRigidbody;
    }

    private Rigidbody SpawnChildCube(Vector3 position, Vector3 scale, float newSplitChance)
    {
        CubeSplit newCube = Instantiate(cubePrefab, position, Quaternion.identity);

        Rigidbody rigidbody = newCube.Rigidbody;
        Color newColor = _colored.GetRandomColor();

        newCube.transform.localScale = scale;
        newCube.SetSplitChance(newSplitChance);
        newCube.ApplyColor(newColor);
        
        return rigidbody;

    }

    public void Despawn(CubeSplit cube)
    {
        Destroy(cube.gameObject);
    }
}
