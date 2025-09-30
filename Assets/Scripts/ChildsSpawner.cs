using System;
using System.Collections.Generic;
using UnityEngine;

public class ChildsSpawner : MonoBehaviour
{
    [SerializeField] private CubeSplit cubePrefab;
    [SerializeField] private Colored _colored;

    public List<Rigidbody> ChildSpawn(CubeSplit parentCube, float splitChance, int childCount, float scaleFactor)
    {
        List<Rigidbody> childrensRb = new List<Rigidbody>();

        Vector3 parentScale = parentCube.transform.localScale;
        Vector3 parentPos = parentCube.transform.position;
        Vector3 childScale = parentScale * scaleFactor;

        float newSplitChance = parentCube.SplitChance * splitChance;

        for (int i = 0; i < childCount; i++)
        {
            var (_, Rigidbody) = SpawnChildCube(parentPos, childScale, newSplitChance);
            childrensRb.Add(Rigidbody);
        }

        return childrensRb;
    }

    public (CubeSplit cube, Rigidbody rigidbody) SpawnChildCube(Vector3 position, Vector3 scale, float newSplitChance)
    {
        CubeSplit newCube = Instantiate(cubePrefab, position, Quaternion.identity);
        Rigidbody rb = newCube.GetComponent<Rigidbody>();

        newCube.transform.localScale = scale;
        newCube.SetSplitChance(newSplitChance);
        _colored.ChangeColor(newCube);

        return (newCube, rb);
    }

    public void Despawn(CubeSplit cube)
    {
        Destroy(cube.gameObject);
    }
}
