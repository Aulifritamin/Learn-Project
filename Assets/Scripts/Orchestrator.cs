using UnityEngine;
using System.Collections.Generic;

public class Orchestrator : MonoBehaviour
{
    [SerializeField] private ClickRayCast _rayCast;
    [SerializeField] private ChildsSpawner _spawner;
    [SerializeField] private Explosion _explosion;

    [SerializeField] private float _childSplitMultiplier = 0.5f;
    [SerializeField] private float _minScale = 0.1f;
    [SerializeField] private float _scaleFactor = 0.5f;

    [SerializeField] private int _minChild = 2;
    [SerializeField] private int _maxChild = 6;

    private void OnEnable()
    {
        _rayCast.RaiseCube += OnCubeClicked;
    }

    private void OnDisable()
    {
        _rayCast.RaiseCube -= OnCubeClicked;
    }

    private void OnCubeClicked(CubeSplit cube)
    {

        float randomSplit = Random.value;

        if (cube.transform.localScale.x < _minScale)
        {
            _spawner.Despawn(cube);
            return;
        }

        if (randomSplit <= cube.SplitChance)
        {
            int randomItemCount = Random.Range(_minChild, _maxChild + 1);

            List<Rigidbody> childrensRigidbody = _spawner.ChildSpawn(cube, _childSplitMultiplier, randomItemCount, _scaleFactor);

            _explosion.AppleExplosion(childrensRigidbody, cube.transform.position);

        }

        _spawner.Despawn(cube);
    }
}
